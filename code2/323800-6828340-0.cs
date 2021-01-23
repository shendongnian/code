    public void Search()
    {
      using (var browser = new IE("http://www.tkyd.org.tr/T/endexes.aspx"))
      {      
        Assert.IsTrue(browser.ContainsText("bla bla"));
      }
    }
