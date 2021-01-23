    public TestForm()
            {
                InitializeComponent();
                ExtendedLabel label = new ExtendedLabel();
                label.MoreInfo = new string[] { "test" };
                this.Controls.Add(label);
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(120, 87);
                label.Name = "label1";
                label.Size = new System.Drawing.Size(35, 13);
                label.TabIndex = 0;
                label.Text = label.MoreInfo[0];            
            }
