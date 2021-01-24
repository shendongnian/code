    @{
        int page = int.TryParse(Request["page"], out page) ? page : 0;
        int pageSize = 5;
    
        var selection = Model.Content
            .Children()
            .Where(x => x.IsVisible())
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }
    <div class="container-fluid">
        ...
    </div>
    <a href="@Request.RawUrl.Split('?')[0]?page=@(page + 1)">
        Load next @pageSize results
    </a>
