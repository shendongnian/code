       public void execute()
       {
           var m = foo_.GetType().GetMethod("bar", BindingFlags.NonPublic|BindingFlags.Instance);
           m.Invoke(foo_, null);
    
       }
