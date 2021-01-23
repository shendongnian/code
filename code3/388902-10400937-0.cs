    public class MyController: AsyncController
       {
           public void IndexAsync(int[] ids)
           {
                var orders = new Orders[ids.Length];
                AsyncManager.Parameters["orders"] = orders;
                // tell the async manager there are X operations it needs to wait for
                AsyncManager.OutstandingOperations.Increment(ids.Length);
                for (int i = 0; i < ids.Length; i++){
                   var index = i; //<-- make sure we capture the value of i for the closure
                   // create the query
                   var query = _context.CreateQuery<Order>("Orders");
                   // run the operation async, supplying a completion routine
                   query.BeginExecute(ar => {
                       try {
                           orders[index] = query.EndExecute(ar).First(o => o.id == ids[index]);
                       }
                       catch (Exception ex){
                           // make sure we send the exception to the controller (in case we want to handle it)
                           AsyncManager.Sync(() => AsyncManager.Parameters["exception"] = ex);
                       }
                       // one more query has completed
                       AsyncManager.OutstandingOperations.Decrement();
                   }, null);
                }
           }
    
           public ActionResult IndexCompleted(Order[] orders, Exception exception)
           {
                if (exception != null){
                    throw exception; // or whatever else you might like to do (log, etc)
                }
                return Json(orders);
           }
    
           private DataServiceContext _context; //let's ignore how this would be populated
       }
