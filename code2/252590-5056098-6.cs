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
            AsyncManager.OutstandingOperations.Decrement();
        }
        public ActionResult ExportCompleted()
        {
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
