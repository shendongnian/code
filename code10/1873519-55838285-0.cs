    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace Application.Models
    {
        public class HealthCheck
        {
            public HealthCheck()
            {
            }
            public HealthCheck(string title, string hctype, string link)
            {
                Title = title;
                HCType = hctype;
                Link = link;
            }
    
            public int Id { get; set; }
            public string Title { get; set; }
            public string HCType { get; set; }
            public string Link { get; set; }
        }
    }
