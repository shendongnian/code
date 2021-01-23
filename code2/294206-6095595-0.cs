            foreach (Control ctl in this.Controls)
            {
                switch (ctl.GetType().ToString())
                {
                    case "TextBox":
                        ctl.Text = null;
                        break;
                    case "ComboBox":
                        ctl.Text = null;
                        break;
                }
            }
