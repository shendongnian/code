    [TestMethod]
    public void TestMethod1()
    {
      string a = @"`1234567890-=[]\ ;',./\~!@#$%^&*()_+{}|:""<>?|";
      Console.WriteLine("Original:");
      Console.WriteLine("{0}", a);
      string htmlEncoded = System.Web.HttpUtility.HtmlEncode(a);
      Console.WriteLine("Html Encoded:");
      Console.WriteLine("{0}", htmlEncoded);
    }
