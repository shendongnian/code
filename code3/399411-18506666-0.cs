    public class ChartResult : ActionResult
    {
        private Chart _chart;
        public ChartResult(Chart chart)
        {
            if (chart == null)
                throw new ArgumentNullException("chart");
            _chart = chart;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
    
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "image/png";
            response.BufferOutput = false;
            _chart.ImageType = ChartImageType.Png;
            _chart.SaveImage(response.OutputStream);
        }
    }
