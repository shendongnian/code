    [HttpPost]
    public ActionResult PlaceCheckout(int assetId, string libraryCardId )
    {
        // This extension method takes int version of libraryCardId
        // So, am really not sure the datatype of libraryCardId
        CheckOutService.Instance.CheckoutItem(assetId, libraryCardId );
    
        return RedirectToAction("Details", new { id = assetId });
    }
