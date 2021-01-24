    var items = data.GetPropertyValue<IEnumerable<IPublishedContent>>("blogNested")
        .ToList();
    
    while (items.Any())
    {
        var oneItem = items.First();
        items.Remove(oneItem);
        <div class="row">
            <div class="col-md-12">
                @oneItem.Id
            </div>
        </div>
        var twoItems = items.Take(2).ToList();
        if (twoItems.Any())
        {
            <div class="row">
                @foreach (var item in twoItems)
                {
                    items.Remove(item);
                    <div class="md-6">
                        @item.Id
                    </div>
                }
            </div>
        }
    }
