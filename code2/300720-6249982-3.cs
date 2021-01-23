    public ActionResult MyAction(FormCollection MyForm)
    {
       String AllValues =MyForm["HiddenFieldName"];
       String[] SeparatedValuse = AllValues.Split(",");
    }
