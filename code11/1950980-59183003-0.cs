    <div class="page home-page custom-container d-flex flex-column">
    @{
        var tasks = new List<Task>();
    
        tasks.Add(Component.InvokeAsync("PersonalizedProducts"));
        tasks.Add(Component.InvokeAsync("RecommendedProducts"));
        tasks.Add(Component.InvokeAsync("SuggestedProducts"));
        tasks.Add(Component.InvokeAsync("HomePageProducts"));
        tasks.Add(Component.InvokeAsync("HomePageNewProducts"));
        tasks.Add(Component.InvokeAsync("CategoryFeaturedProducts"));
    
        await Task.WhenAll(tasks);
        foreach( var t in tasks)
        {
            var var1 = await t;
            @var1;
        }
    }
    </div> 
   
