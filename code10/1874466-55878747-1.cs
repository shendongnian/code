    var items = data.GetPropertyValue<IEnumerable<IPublishedContent>>("blogNested")
        .ToList();
    
    while(items.Any())
    {
        var oneItem = items.First();
        items.Remove(oneItem);
        <div class="1-column">@oneItem.Id<p>
        
        var twoItems = items.Take(2).ToList();
        if(twoItems.Any())
        {
            <div class="2-columns">
                foreach(var item in twoItems)
                {
                    items.Remove(item);
                    <div class="column">@item.Id</div>
                }
            </div>
        }
    }
