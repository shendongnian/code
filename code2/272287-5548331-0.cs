    foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    if ((c as CheckBox).IsChecked == true)
                        // do something
                }
            }
