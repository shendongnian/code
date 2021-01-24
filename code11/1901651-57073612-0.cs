    [HttpGet]
    public IActionResult FileToTextToHtml()
        {
            string fileContents = System.IO.File.ReadAllText("D:\\HtmlTest.html");
            var result= new ContentResult()
            {
                Content = fileContents,
                ContentType = "text/html",
            };
            return result;
        }
