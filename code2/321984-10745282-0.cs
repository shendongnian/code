        var sb = new StringBuilder();
        var context = new ViewContext();
        context.ViewData = new ViewDataDictionary(_testModel);
        context.Writer = new StringWriter(sb);
        var page = new ViewPage<TestModel>();
        var helper = new HtmlHelper<TestModel>(context, page);
        //Do your stuff here to exercise your helper
        
        //Following example contains two helpers that are being tested
        //A MyCustomBeginForm Helper and a OtherCoolHelperIMade Helper
        using(helper.MyCustomBeginForm("secretSauce"))
        {
           helper.ViewContext.Writer.WriteLine(helper.OtherCoolHelperIMade("bigMacSauce"));
        }
        //End Example
        //Get the results of all helpers
        var result = sb.ToString();
        //Asserts and string tests here for emitted HTML
        Assert.IsNotNullOrEmpty(result);
