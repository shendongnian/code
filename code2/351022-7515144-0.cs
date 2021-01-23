    public void DoWhatEver()
    {
       using (var foo = CreateFoo())
       {
         if (foo == null) return;
         //DoWhatEver
       }
    }
