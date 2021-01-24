    public class DateTimeResourceFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            const string PreferredDateTimeFormat = "yyyy-MM-dd";
            string dateTimeString = context.HttpContext.Request.Query["StartDate"].First();
            bool isPreferredDateTimeFormat = DateTime.TryParseExact(dateTimeString, PreferredDateTimeFormat, new CultureInfo("en-AU"), DateTimeStyles.None, out DateTime dateTime);
            if (!isPreferredDateTimeFormat)
            {
                context.Result = new ContentResult()
                {
                    Content = $"Date must be in the following format: {PreferredDateTimeFormat}",
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }
    
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
