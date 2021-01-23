     public class State
            {
                public int SID { get; set; }
                public string SName { get; set; }
                public string SCode { get; set; }
                public string SAbbrevation { get; set; }
            }
    
            public class Country
            {
                public int CID { get; set; }
                public string CName { get; set; }
                public string CAbbrevation { get; set; }
            }
    
    
     List<State> states = new List<State>()
                {
                   new  State{  SID=1,SName="Telangana",SCode="+91",SAbbrevation="TG"},
                   new  State{  SID=2,SName="Texas",SCode="512",SAbbrevation="TS"},
                };
    
                List<Country> coutries = new List<Country>()
                {
                   new Country{CID=1,CName="India",CAbbrevation="IND"},
                   new Country{CID=2,CName="US of America",CAbbrevation="USA"},
                };
    
                var res = coutries.Join(states, a => a.CID, b => b.SID, (a, b) => new {a.CName,b.SName}).ToList();
