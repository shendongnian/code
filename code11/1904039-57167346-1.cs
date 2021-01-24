        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                switch (item.GetType().Name)
                {
                    case "Label":
                        if (((Label)item).BorderStyle == BorderStyle.None)
                        {
                            //Your commands
                        }
                    break;
                    case "TextBox":
                        if (((TextBox)item).BorderStyle == BorderStyle.None)
                        {
                            //Your commands
                        }
                   break;
                }
            }
        }
