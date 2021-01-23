    public override bool Equals (object obj)
    {
        #if TEST
         // Your implementation
        #else
          return base.Equals (obj);
        #endif
    }
