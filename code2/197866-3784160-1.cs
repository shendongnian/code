    class TestableStore : Store { 
      public int TestableId { 
        get { return Id; }
        set { Id = value; }
      }
    }
