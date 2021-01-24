            dt.DefaultView.Sort = "ID";
            int horizontal = 0;
            int vertical = 0;
            Button[] buttonArray = new Button[dt.Rows.Count];
            for (int items = 0; items < buttonArray.Length; items++)
            {
                buttonArray[items] = new Button();
                buttonArray[items].Size = new Size(150, 50);
                buttonArray[items].Location = new Point(horizontal, vertical);
                buttonArray[items].Name = string.Format("Button_{0}", dt.DefaultView[items].Row["ID"].ToString());
                buttonArray[items].Text = dt.DefaultView[items].Row["Name"].ToString();
                buttonArray[items].Click += btn_msg;
                if ((items + 1) < buttonArray.Length)
                {
                    vertical += 50;
                }
                flowLayoutPanel_AttackName.Controls.Add(buttonArray[items]);
            }
