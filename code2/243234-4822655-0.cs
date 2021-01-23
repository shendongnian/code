    public class Form1ViewModel() // This will hold all the fields you need in the form
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        // etc...
    }
    public class Form1PostModel()
    {
      public string Value1 { get; set; }
      public string Value2 { get; set; }
      // add for each post value you expect
    }
    public class ReturnModel() // some object to hold the values you want to return
    {
       public string Message { get; set; }
       public bool Success { get; set; }
    }
