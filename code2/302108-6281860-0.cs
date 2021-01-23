    for (int item = 0; item < Repeater.Items.Count; item++)
    {
       CheckBox box = Repeater.Items[item].FindControl("CheckBoxID") as CheckBox;
       if (box.Checked)
       {
          DoStuff();
       }
       else
       {
          DoOtherStuff();
       }
    }
