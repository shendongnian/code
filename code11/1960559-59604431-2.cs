    public async Task<IActionResult> Index() {
        IEnumerable<StockDto> stocks = null;
        try {
            stocks = await _stockService.GetStockAsync();
        }
        catch (HttpRequestException) {
            stocks = Array.Empty<StockDto>();
        }
        return View(stocks.ToList());
    }
