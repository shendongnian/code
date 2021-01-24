    [HttpGet("{searchText}/{filterType}")] 
    public async Task<ActionResult<List<Stock>>> Get(string searchText, string filterType)
     {
        var v = await this._context.StockView
                  .Where(x => x.Type == filterType 
                           && x.SearchField == searchText).TolistAsync();
    
        return this.Ok(v);
     }
