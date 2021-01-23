    struct V { public int x = 0; }
    class  R { public int y = 0; }
    void F() 
    {
       V a;   // a is an instance of V  
       R b;   // b is a reference to an R
       a.x = 1; // OK, the memory exists
     //b.y = 2; // error, there is no instance yet
       b = new R();  // allocates new memory
       a = new V();  // overwrites memory
       
    }
   
