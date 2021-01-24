    public class XXXWriter
    {
        public static void FireAndForget(XXX model)
        {
           Task.Run(() => DoFireAndForgetAsync(model));
        }
 
        private void DoFireAndForgetAsync(XXX model)
        {
            try
            {
                using (var ctx = new FormsEntities())
                {
                    var dbXXX = new DALXXX();
                    dbXXX.Foo = model.Foo;            
                
                    ctx.DALXXX.Add(dbXXX);
                    ctx.SaveChanges();
               
                }
            }catch (Exception ex)
             {
         
                // Remember that the Async code needs to handle its own
                // exceptions, as the "DoFireAndForget" method will never fail
                   Log.Log.LogError(ex.GetMostInnerException(), "whatever");
             }
         }
    }
