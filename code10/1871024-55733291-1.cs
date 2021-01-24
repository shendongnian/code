    public async Task<ActionResult> GetInventoryDetails(string stockNumber)
    {
      var viewModel = new InventoryDetailsViewModel
      {
        Inventory = await GetInventoryById(stockNumber),
        Actions = await GetInventoryActions(stockNumber)
      };
      return View(viewModel);
    }
