    Form op = new Form();
                FlowLayoutPanel panel = new FlowLayoutPanel();
                op.Controls.Add(panel);
                for (int i = 0; i < 10; i++)
                {
                    Button b = new Button();
                    b.Text = "Button" + i.ToString();
                    panel.Controls.Add(b);
     
                }
