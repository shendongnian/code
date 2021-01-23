    public void TryStatements(params Action[] actions)
    {
       foreach(Action act in actions)
       {
         try
         {
            act();
         }
         catch(SomeCommonException ex)
         {
            //do something special
         }
         catch(Exception ex)
         {
            //something else
         }
       }
    }
