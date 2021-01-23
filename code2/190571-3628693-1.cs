    foreach (DropDownList dd in this.Controls
                                    .All()
                                    .OfType<DropDownList>()
                                    .Where(c => c.Attributes["foo"] == "bar"))
    { 
        // do something              
    }
    ...
    //define the extension method.
    public static IEnumerable<Control> All(this ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            foreach (Control grandChild in control.Controls.All())
                yield return grandChild;
            yield return control;
        }
    }
