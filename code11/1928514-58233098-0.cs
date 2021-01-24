    public class RewriteRouteRule
    {
        public static void ReWriteRequests(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            if (request.Path.Value.Contains("values"))
            {
                string[] splitlist = request.Path.Value.Split("/");
                var newarray = splitlist.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                var newpath = "";
                foreach (var item in newarray)
                {
                    newpath += "/" + item;
                }
                request.Path = newpath;
            }
        }
    }
