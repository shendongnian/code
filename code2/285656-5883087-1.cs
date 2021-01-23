    public static implicit operator MyTypeB( MyTypeA a ) {
      MyTypeB b = new MyTypeB();
      // copy all a properties
      return b;
    }
