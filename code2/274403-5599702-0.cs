        class Test {
      public static void Main() {
        ResourceWriter rw = new ResourceWriter("English.resources");
        rw.AddResource("Name", "Test");
        rw.AddResource("Ver", 1.0 );
        rw.AddResource("Author", "www.java2s.com");
        rw.Generate();
        rw.Close();
      }
    }
