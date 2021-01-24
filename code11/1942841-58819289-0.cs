    [HttpPost]
    [Authorize]
    public IActionResult AddInvoiceRest([FromBody]InvoiceDetailModel model) {
        if(ModelState.IsValid) {
            AddInvoiceRetailRest[] invoiceDetail = model.InvoiceDetail;
            //...
        }
        return BadRequest(ModelState);
    }
