     public void Bar()
     {
         ...
         DoAction(condition);
         ...
     }
     public void Foo()
     {
         ...
         DoAction(condition);
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
     private void DoAction(bool condition)
     {
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
     }
