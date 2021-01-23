    public class AdSequencePostProcessingFilterAttribute : ActionFilterAttribute
    {
        private Stream _output;
        private const string AdSequenceMarker = ":{ad_sequence}";
        private const char AdSequenceStart = ':';
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Capture the original output stream;
            _output = filterContext.HttpContext.Response.Filter;
            filterContext.HttpContext.Response.Flush();
            filterContext.HttpContext.Response.Filter = new CapturingResponseFilter(filterContext.HttpContext.Response.Filter);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //Get the emitted markup
            filterContext.HttpContext.Response.Flush();
            CapturingResponseFilter filter = 
                (CapturingResponseFilter)filterContext.HttpContext.Response.Filter;
            filterContext.HttpContext.Response.Filter = _output;
            string html = filter.GetContents(filterContext.HttpContext.Response.ContentEncoding);
            //Replace the marker string in the markup with incrementing integer
            int adSequenceCounter = 1;
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < html.Length; i++)
            {
                char c = html[i];
                if (c == AdSequenceStart && html.Substring(i, AdSequenceMarker.Length) == AdSequenceMarker)
                {
                    output.Append(adSequenceCounter++);
                    i += (AdSequenceMarker.Length - 1);
                }
                else 
                {
                    output.Append(c);
                }
            }
            //Write the rewritten markup to the output stream
            filterContext.HttpContext.Response.Write(output.ToString());
            filterContext.HttpContext.Response.Flush();
        }
    }
