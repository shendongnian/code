     class MainClass : IInterface_1, IInterface_2 {        
        public string field_1{get;set;}
        public string field_3{get;set;}
        public string field_4{get;set;}
        private string field2;
        string IInterface_1.field_2 {
            get {return field2;}
            set {field2 = value;}
        }
     }
