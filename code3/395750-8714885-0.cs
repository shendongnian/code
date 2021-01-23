    public void MyEventHasFired()
    {
         DateTime dateLastProcessed = ... //Database? Session data? Anything goes.
         if(dateLastProcessed < DateTime.Now.AddMinutes(-10))
         {
              //calculate
              ...
              dateLastProcessed = DateTime.Now;
         }
    }
