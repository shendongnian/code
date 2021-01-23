    public class BackgroundController : AsyncController
    {
        public void ExportAysnc(int id)
        {
            AsyncManager.OutstandingOperations.Increment();
            Task.Factory.StartNew(() => DoLengthyOperation(id));
        }
        private void DoLengthyOperation(int id)
        {
            SalesInvoice invoice = _salesService.GetById(id);
            AsyncManager.Parameters["result"] = ExportTo3rdParty(invoice);
            AsyncManager.OutstandingOperations.Decrement();
        }
        public ActionResult ExportCompleted(SomeResult result)
        {
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
