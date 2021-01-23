    protected override void OnLoad(EventArgs e)
    {
        if(!Page.IsPostBack)
             {
                 if(Text == String.Empty)
                 {
                     if (SampleText != "")
                     {
                                CssClass = "sampleText";
                                this.Text = SampleText;
                                var onFocus = "<script language=\"javascript\">function ClearField(input) { if(input.value == input.defaultValue){input.value = \"\"; input.className = 'regularText';} } </script>";
                                var onBlur = "<script language=\"javascript\"> function PopulateField(input) {if (input.value == \"\") {input.value = input.defaultValue; input.className = 'sampleText'; } } </script>";
    
                                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "OnFocus", onFocus);
                                this.Attributes.Add("onfocus", "ClearField(this);");
    
                                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "OnBlur", onBlur);
                                this.Attributes.Add("onblur", "PopulateField(this);");
    
                                this.Attributes.Add("Mask", this.Mask);
                            }
                        }
                    }
                }
