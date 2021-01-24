    public IActionResult MyControllerMethod(SomeRequest request)
    {
        // Call your business model to receive the desired string...
        var content = "\x{data,BARCODE,004}\x";
        return Content(content);
        // Or for full control
        // return new ContentResult { Content = content, ContentType = "text/glibberish", StatusCode = 418 };
    }
