    struct EvilStruct
    {
        public readonly object Obj;
     
     public void SetToNull()
     {
       this=new EvilStruct();
     }
     
     public EvilStruct(object obj)
     {
       Obj=obj;
     }
    }
    
    readonly EvilStruct s1=new EvilStruct(new object());
    EvilStruct s2=new EvilStruct(new object());
    
    void Main()
    {
        s1.SetToNull();
     s2.SetToNull();
     s1.Obj.Dump();//An instance of System.Object
     s2.Obj.Dump();//null
     //now s1.Obj can't be collected, but what was once in s2.Obj can
    }
