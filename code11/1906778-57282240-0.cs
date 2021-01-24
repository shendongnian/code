c#
        class Something
        {
            public string PhysicalName { get; set; }
        }
        private void AddLabels()
        {
            Something[] channelCollection = new Something[]
            {
                //Applying this to Label.Text makes it "invisible"
                new Something() { PhysicalName = "" }
            };
            var currentChannelIndex = 0;
            var txt = new TextBox();
            txt.Name = channelCollection[currentChannelIndex].PhysicalName;
            txt.Text = "ben";
            txt.Location = new Point(200, 32);
            txt.Visible = true;
            this.Controls.Add(txt);
            var lbl = new Label();
            lbl.AutoSize = true;
            lbl.Name = channelCollection[currentChannelIndex].PhysicalName;
            lbl.Size = new Size(55, 13);
            lbl.TabIndex = 69;
            lbl.Text = channelCollection[currentChannelIndex].PhysicalName;
            lbl.Location = new Point(175, 32);
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Controls.Add(lbl);
        }
