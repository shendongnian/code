    // appends a string class to the html controls class attribute
    public static void AddClass(this HtmlControl control, string newClass)
    {
        if (control.Attributes["css"].IsNotNullAndNotEmpty())
        {
            control.Attributes["css"] += " " + newClass;
        }
        else
        {
            control.Attributes["css"] = newClass;
        }
    }
