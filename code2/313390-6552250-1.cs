    if (Request.Form["DeleteWidgetValue"] != null)
    {
        var itemToRemove = Request.Form["ListBoxWidgetValues"];
        var index = widget.Values.IndexOf(itemToRemove);
        ModelState.Remove("Values[" + index + "]");
        widget.Values.Remove(itemToRemove);
        return View("EditWidget", widget);
    }
