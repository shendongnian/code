    public void traverse(Control ctl)
    {
        foreach (Control c in ctl.Controls) 
        {
            System.Diagnostics.Debug.WriteLine(c.GetType().ToString());
            //Response.Write(c.GetType().ToString() + " : " + c.ID.ToString() + "<br />"); 
            if (c.GetType() == typeof(TextBox)) 
            { ((TextBox)(c)).Attributes["onKeypress"] = "javascript:return FormEdited();"; 
            } 
            if (c.GetType() == typeof(DropDownList)) 
            { ((DropDownList)(c)).Attributes["onchange"] = "javascript:return FormEdited();"; 
            } 
            else if (c.GetType() == typeof(CheckBox)) 
            { ((CheckBox)(c)).Attributes["onClick"] = "javascript:return FormEdited();"; 
            }
            traverse(c);
        }
    }
