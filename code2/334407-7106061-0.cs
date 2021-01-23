    foreach (Control ctrl in Panel1.Controls)
        {
            if (ctrl.GetType().Name == "TextBox")
            {
                if (((TextBox)ctrl).Text != string.Empty)
                {
                    // do stuff here
                }
           }
       } 
