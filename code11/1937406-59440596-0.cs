    public ActionResult PrintInvoice(string name, string address)
    {
        return new ActionAsPdf("Print", new { name, address });
    }
    public ActionResult Print(string name, string address)
    {
      //use code to render your view and try to adjust position using HTML and CSS.
    }
