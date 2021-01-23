    class Data : Postable { public string Param1{get;set;} public string Param2{get;set;} ...}
    class Postable 
    { 
        public override string ToString() 
        { 
            StringBuilder ret = new StringBuilder();
            foreach(Property p in GetType().GetProperties())
            {
                ret.Append("{0}={1}&", p.Name, p.<GetValue>);
            }
            return ret.ToString();
        } 
    }
