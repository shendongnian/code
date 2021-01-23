    public class MyDataClass
    {
        public string TextColumn {get; set;}
        public int NumberColumn0 {get; set;}
        public int NumberColumn1 {get; set;}
        public int Total
        {
            get { return NumberColumn0 + NumberColumn1; }
        }    
    }
