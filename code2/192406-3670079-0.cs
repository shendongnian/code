        // 
        // cbTaggedRecords
        // 
        this.cbTaggedRecords.AutoSize = true;
        this.cbTaggedRecords.Location = new System.Drawing.Point(151, 9);
        this.cbTaggedRecords.Name = "cbTaggedRecords";
        this.cbTaggedRecords.Size = new System.Drawing.Size(106, 17);
        this.cbTaggedRecords.TabIndex = 3;
        this.cbTaggedRecords.Text = "Tagged Records";
        this.cbTaggedRecords.UseVisualStyleBackColor = true;
        this.cbTaggedRecords.CheckedChanged += new System.EventHandler(this.ShowTaggedRecords_CheckChanged);
        // 
        // cbAllErrorReports
        // 
        this.cbAllErrorReports.AutoSize = true;
        this.cbAllErrorReports.Location = new System.Drawing.Point(6, 9);
        this.cbAllErrorReports.Name = "cbAllErrorReports";
        this.cbAllErrorReports.Size = new System.Drawing.Size(102, 17);
        this.cbAllErrorReports.TabIndex = 2;
        this.cbAllErrorReports.Text = "All Error Reports";
        this.cbAllErrorReports.UseVisualStyleBackColor = true;
        this.cbAllErrorReports.CheckedChanged += new System.EventHandler(this.ShowAllErrorReports_CheckChanged);
        // 
        // listView1
        // 
        this.listView1.CheckBoxes = true;
        listViewItem1.StateImageIndex = 0;
        listViewItem2.StateImageIndex = 0;
        listViewItem3.StateImageIndex = 0;
        listViewItem4.StateImageIndex = 0;
        listViewItem5.StateImageIndex = 0;
        listViewItem6.StateImageIndex = 0;
        listViewItem7.StateImageIndex = 0;
        listViewItem8.StateImageIndex = 0;
        listViewItem9.StateImageIndex = 0;
        this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
        listViewItem1,
        listViewItem2,
        listViewItem3,
        listViewItem4,
        listViewItem5,
        listViewItem6,
        listViewItem7,
        listViewItem8,
        listViewItem9});
        this.listView1.Location = new System.Drawing.Point(6, 29);
        this.listView1.Name = "listView1";
        this.listView1.Size = new System.Drawing.Size(281, 295);
        this.listView1.TabIndex = 1;
        this.listView1.UseCompatibleStateImageBehavior = false;
        this.listView1.View = System.Windows.Forms.View.List;
        this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView_ItemChecked);
