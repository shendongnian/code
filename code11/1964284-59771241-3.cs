    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace Test2.Models
    {
        
        public class AccountVM
        {
            public AccountVM()
            {
                AccountOrOU = new AccountOrOU();
            }
            public AccountOrOU AccountOrOU { get; set; }
        }
    
        public class AccountOrOU
        {
            public string Name { get; set; }
        }
    }
