    class Program
    {
        static void Main(string[] args)
        {
             DataClasses1DataContext ctx = new DataClasses1DataContext();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                   
                    ctx.Table_1s.InsertOnSubmit(new Table_1
                    {
                        Name = "John"
                    });
                    ctx.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                }
                var list = from i in ctx.Table_1s
                           select i;
                foreach (var item in list)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //OUTPUT: "John"
            //        "John"
            //        "John" 
            //        "John"
            //        "John"
            //        "John"
            //        "John"
            //        "John"
            //        "John"
            //        "John"
            //        "John"
        }
    }
