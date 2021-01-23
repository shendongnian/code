    struct LogDescrition
    {
       public int LogBase {get;set;}
       public override ToString()
       { return string.Format("{0}.log", LogBase); }
    }
