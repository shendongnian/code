    struct V { int x; }
    class R { int y; }
    void F() 
    {
       V a;   // a is an instance of V  
       R b;   // b is a reference to an R
       a.x = 1; // OK, the memory exists
     //b.y = 2; // error, there is no instance yet
       b = new R();  // allicates new memory
       a = new A();  // overwrites memory
       
    }
   
