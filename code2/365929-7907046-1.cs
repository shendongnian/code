    public class YourViewModel 
    {
        public List<A> ListA {get; set;}
        public List<B> ListB {get; set;}
    }
    public ActionResult YourControllerAction()
    {
       var context = yourDataContext;
       var model = new YourViewModel
       {
          ListA = context.TableA.Where(x => x.Something)
                         .Select(x => x.ConvertSqlToBusinessObject()).ToList(),
          ListB = context.TableB.Where(x => x.Something)
                         .Select(x => x.ConvertSqlToBusinessObject()).ToList()
       };
       return View("Index",model);
    }
