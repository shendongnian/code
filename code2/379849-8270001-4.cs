     public void Bar()
     {
         ...
         if (condition)
         {
             Action1();
             Action2();
         }
         else
         {
             Action2();
             Action1();
         }
         ...
     }
     public void Foo()
     {
         ...
         if (condition)
         {
             Action1();
             Action2();
         }
         else
         {
             Action2();
             Action1();
         }
         ...
     }
     private void Action1()
     {
         //code for action 1
     }
     private void Action2()
     {
         //code for action 1
     }
