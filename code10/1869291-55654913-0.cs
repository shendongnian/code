    [Route("package/{package}/[controller]", Name = "Invoice")]
    public class InvoiceController : ControllerBase {
    
        //GET package/BillingPackage/Invoice
        [HttpGet()]
        public ActionResult<Invoice> Get(string package) {
            return new SampleInvoice();
        }
    }
