    // appends a string class to the html controls class attribute
    public static void AddClass(this HtmlControl control, string newClass)
    {
        if (control.Attributes["class"].IsNotNullAndNotEmpty())
        {
            control.Attributes["class"] += " " + newClass;
        }
        else
        {
            control.Attributes["class"] = newClass;
        }
    }
