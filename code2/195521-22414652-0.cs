    public class PartialViewConverter : ViewResult
    {
        public ViewResultBase Res { get; set; }
        public PartialViewConverter(ViewResultBase res) { Res = res; }
        public override void ExecuteResult(ControllerContext context)
        {
            Res.ExecuteResult(context);
        }
        public static ViewResult Convert(ViewResultBase res)
        {
            return new PartialViewConverter(res);
        }
    }
