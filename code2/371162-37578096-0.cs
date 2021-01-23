    // Now I create my checkbox
    chkDynamic = new CheckBox();
    string chk = "chk";
    
    // Add it to our dynamic control
    chkDynamic.CheckedChanged += delegate (System.Object o, System.EventArgs e)
            {
               if (((CheckBox)sender).Checked)
               Response.Write("you checked the checkbox :" + this.chkDynamic.ID);
               else
               Response.Write("checkbox is not checked");
            };
    chkDynamic.ID = chk;
    DynamicControlsPlaceholder1.Controls.Add(chkDynamic);
    chkDynamic.Text = "hey";
