    @{ 
        var sidebarContents= new StringBuilder(); 
        foreach(var x in y)
        {
            sidebarContents.append("<div>Some Potentially Long nasty HTML STRING" + x.Something + "</div>");
        }
    }
    @sidebarTemplate (new Sidebar()
    { 
        Title = "title",
        Contents = Html.Raw(sidebarContents.ToString())
    })
