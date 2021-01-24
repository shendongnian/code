    public async Task<List<items>> getService(List<string> ids)
    {
        var IdentificationIdsToOrder = new JObject();
        foreach (var id in ids)
        {
            var newId = new JProperty("ids", id);
            IdentificationIdsToOrder.Add(newId);
        }
        _controller = new getitems();
        var Res = await _controller.getitems();         
        var ItemList = Res.Value;
        return ItemList;
    }
