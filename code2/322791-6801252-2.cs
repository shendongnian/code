    class Program
    {
        static void Main(string[] args)
        {
            IUserDataManager mgr = new AccessUserDataManager("access.db");
            mgr.Validate();
            mgr.SaveFile();
            mgr.DeleteFile();
    
            mgr = new ExcellUserDataManager("excel.xlsx");
            mgr.Validate();
            mgr.SaveFile();
            mgr.DeleteFile();
    
            Console.ReadLine();
        }
    }
