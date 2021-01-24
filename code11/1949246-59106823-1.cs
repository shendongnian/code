    [Authorize(Policy = "ShouldHaveMerchantId")]
    public async Task<IActionResult> YourActionMethod()
    {
        //Your logic
    }
