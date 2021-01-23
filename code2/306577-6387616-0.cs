    class FileOne
    { 
        public int LineNumber {get;set};
        public int Id{get;set;}; 
        public double Bal {get;set;};
    ...
    }
    class FileTwo
    { 
        public int LineNumber {get;set};
        public string TranType{get;set;};  // type = reserved word
        public int Id{get;set;}; 
        public double Bal {get;set;};
    ...
    }
