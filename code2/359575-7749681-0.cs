    using System.Linq;
    
    namespace ConsoleApplication11    {
        class Program
        {
            string me_login_name;
            int me_pkey;
        
            public static void Main()
            {
                new Program().Run();
            }
    
            private void Run()
            {
                IQueryable<v2oneboxDataEntity> me_employees = null;
        
                var duplicate =
                    from  loginId in me_employees
                    where loginId.me_login_name == this.me_login_name
                            && loginId.me_pkey != this.me_pkey
                    select loginId;
                
                var count = duplicate.Count();            
            }
        
            // Define other methods and classes here
            class v2oneboxDataEntity 
            {
                public string me_login_name { get; set; }
                public int me_pkey { get; set; }
            }
        }
    }
