      private static MyClass _instance;
      public MyClass Instance // note the getter is not static
      {
          get
          {
              if (_instance == null)
                  _instance = new MyClass();
              return _instance;
          }
      }
