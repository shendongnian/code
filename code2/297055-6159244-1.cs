    public class OrderModel
    {
        public string[] List { get; set; }
    }
    public ActionResult OrderProcessor(OrderModel model)
    {
        string[] ids = model.List;
    }
