    class MyClass : SomeBaseClass
    {
       string teamsite;
       protected override void test ()
       {
          string teamsitefinal = teamsite;
       }
       private void test2 ()
       {
          teamsite = "test";
       }
    }
