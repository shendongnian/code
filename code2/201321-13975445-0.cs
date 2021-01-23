    struct Blah { 
       public int value;
       public void Add(int Amount) { value += Amount; }
       public static void Add(ref Blah it; int Amount; it.value += Amount;}
    }
