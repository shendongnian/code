    public class HybridViewResult : ActionResult
    {
        public string ViewName { get; set; }
        public HybridViewResult () { }
        public HybridViewResult (string viewName ) { this.ViewName = viewName ; }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            var usePartial = ShouldUsePartial();
            ActionResult res = GetInnerViewResult(usePartial);
            res.ExecuteResult(context);
        }
        private ActionResult GetInnerViewResult(bool usePartial)
        {
            var view = ViewName;
            ActionResult res;
            if(String.IsNullOrEmpty(view)) {
                 res = usePartial ? new PartialViewResult(view) : new ViewResult(view);
            }
            else {
                 res = usePartial ? new PartialViewResult() : new ViewResult();
            }
            return res;
        }
        private bool ShouldUsePartial(ControllerContext context) {
            return false; //your code that checks if you need to use partial here
        }
    }
