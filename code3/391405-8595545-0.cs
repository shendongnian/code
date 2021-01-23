         var mycbs = new Dictionary<string,<System.Windows.Forms.CheckBox>>();
         foreach (DataRow row in tblAllTests.Rows)
         {
            string cbNewName = cbName + cbTab.ToString();
            mycbs[cbNewName] = new System.Windows.Forms.CheckBox();
            this.testInfoSplitContainer.Panel2.Controls.Add(mycbs[cbNewName]);
            mycbs[cbNewName].AutoSize = true;
            mycbs[cbNewName].Location = new System.Drawing.Point(6, cbPosition);
            mycbs[cbNewName].Name = cbNewName;
            mycbs[cbNewName].Size = new System.Drawing.Size(15, 14);
            mycbs[cbNewName].TabIndex = cbTab;
            mycbs[cbNewName].Text = row["itemDesc"].ToString();
            cbPosition = cbPosition + 22;
            cbTab = cbTab + 1;
        }
