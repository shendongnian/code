     public void randtest()
     {
         var rand = new Random();
         var obj1 = new object();
         var obj2 = new object();
         
         if (rand.Next() % 2 == 1)
         {
             method(obj1);
         }
         else
         {
             method(obj2);
         }
    
     }
    
    public void method(object thing)
    {
        //here i have no way to tell if thing is obj1 or obj2;
    }
