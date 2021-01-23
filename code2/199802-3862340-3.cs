    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new ObjectContext("name=TestEntities");
    
            var institute = ctx.CreateObjectSet<Institute>().First();
    
            System.Console.WriteLine("{0}, {1}", institute.InstituteID, institute.Name);
            foreach (string data in institute.Data)
                System.Console.WriteLine("\t{0}", data);
            
            institute.Data = new string[] { 
                "New value 1",
                "New value 2",
                "New value 3"
            };
    
            ctx.SaveChanges();
        }
    }
