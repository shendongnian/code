    public List<string> names {
      get {
        Monitor.Enter(_names); 
        try {
          return _names;
        } finally {
          Monitor.Exit(_names);
        }
      }
    }
