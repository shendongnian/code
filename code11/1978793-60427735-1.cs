    [HttpPost]
    public void Ajax(int item,string action)
    {
        if (HttpContext != null && HttpContext.Request.HasFormContentType)
        {
            foreach (var key in HttpContext.Request.Form.Keys)
            {
            }
        }
    }
