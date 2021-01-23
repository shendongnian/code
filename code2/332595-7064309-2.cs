            List<GroupBox> GroupBoxes = new List<GroupBox>();
            List <ComboBox> Caja =new List<ComboBox>();
            for (int i = 0; i < Campos.Count; i++)
            {
                ComboBox cb = new ComboBox();
                cb.Location = new System.Drawing.Point(51, 21);
                cb.Name = "comboBox"+i.ToString();
                cb.Size = new System.Drawing.Size(121, 21);
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                Caja.Add(cb);
                GroupBox gb = new GroupBox();
                gb.Location = new System.Drawing.Point(51, 21);
                gb.Size = new System.Drawing.Size(203, 56);
                gb.Text = "haha";
                gb.Name ="GroupBox"+i.ToString();
                gb.Controls.Add(cb);
                GroupBoxes.Add(gb);
                this.flowLayoutPanel1.Controls.Add(gb);
            }
        }
