    // Register colorbox css
                string css = "<link href=\"" + Page.ClientScript.GetWebResourceUrl(typeof(DoctypeSelectorControl),"Umbraco.Datatypes.DoctypeSelector.Styles.colorbox.css") + "\" type=\"text/css\" rel=\"stylesheet\" />";
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(DoctypeSelectorControl), "cssFile", css, false);
    
                // Register doctype javascript
                this.Page.ClientScript.RegisterClientScriptInclude(
                    "Umbraco.Datatypes.DoctypeSelector.doctypeSelector.js",
                    this.Page.ClientScript.GetWebResourceUrl(typeof(DoctypeSelectorControl), "Umbraco.Datatypes.DoctypeSelector.Control.DoctypeSelector.js"));
