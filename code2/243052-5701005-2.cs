     // Create your control
     System.Windows.Forms.Button trialButton = new Button();
     trialButton.Text = "Trial Button";
     
     // Tool tip string
     string toolTipText = "Hello World";
     // ToolTip toolTip = new ToolTip(this.components);
     ToolTip toolTip = new ToolTip();
     toolTip.ToolTipTitle = "ToolTip Title";
     toolTip.UseAnimation = true;
     toolTip.UseFading = true;
     toolTip.IsBalloon = true;
     toolTip.Active = true;
     toolTip.SetToolTip(button, toolTipText);
