    public class ReceiverController : Controller
        {
            public ActionResult Receive1(SenderModel Sender)
            {
                ReceiverModel receiver = new ReceiverModel { Title = "Receiver1" };
                receiver.Color = Sender.Color;
                return PartialView("MessageReceiver", receiver);
            }
            public ActionResult Receive1(SenderModel Sender) { ... }
    }
