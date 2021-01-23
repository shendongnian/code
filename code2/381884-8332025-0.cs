    var vdd = new ViewDataDictionary();
    var tdd = new TempDataDictionary();
    var controllerContext = this.ControllerContext;
    var view = new RazorView(controllerContext, "~/", "~/", false, null);
    var html = new HtmlHelper(new ViewContext(controllerContext, view, vdd, tdd, new StringWriter()),
         new ViewDataContainer(vdd), RouteTable.Routes);
    var a = "Email is locked, click " + LinkExtensions.ActionLink(html, "here to unlock.", "unlock", "controller").ToString();
