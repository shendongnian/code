    public class BackgroundController : AsyncController
    {
        public void ExportAysnc(int id)
        {
            AsyncManager.OutstandingOperations.Increment();
            // that's the web service client proxy that should
            // contain the async versions of the methods
            var someService = new SomeService();
            someService.ExportTo3rdPartyCompleted += (sender, e) =>
            {
                AsyncManager.Parameters["result"] = e.Value;
                AsyncManager.OutstandingOperations.Decrement();
            };
            var invoice = _salesService.GetById(id);
            someService.ExportTo3rdPartyAsync(invoice);
        }
        public ActionResult ExportCompleted(SomeResult result)
        {
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
