      public static Action WrapAction(Action a)
      {
       var invList = ((MultiCastDelegate)a).GetInvocationList();
    
       for (int i = 0; i < invList.Length; i++)
       {
        invList[i] = ()=>{try invList[i] catch {...} });
       }
       return (Action)MulticastDelegate.Combine(invList);
      }
