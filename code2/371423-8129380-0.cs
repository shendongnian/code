    private static IEnumerable<Model> ModelsToTest
    {
      get
      {
        Model x = new Model();
        x.Load("X");
        yield return x;
        Model y = new Model();
        y.Load("Y");
        yield return y;
      }
    }
    [Test]
    public void TestFooCase1([ValueSource("ModelsToTest")] Model model)
    {
      // Code for test case that tests _foo and uses the data model       
    } 
