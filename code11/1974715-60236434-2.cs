    foreach (Control item in flowLayoutPanel2.Controls)
            {
                if (item is Label)
                {
                    Label lbl = (Label)item; //C# özgü
                                             //Label lbl = item as Label; Label lbl = item as Label; // V.B özgü ama ikiside olur.
                    if (lbl.Tag!=null && lbl.Tag.ToString() == clicked.Text)
                    {
                        lbl.Text = clicked.Text;
                        Score += 100;
                        IsCharOpened = true;
                    }
                }
            }
