    System.Windows.Forms.GroupBox StringsGroup;
    System.Windows.Forms.Panel StingPanel;
    System.Windows.Forms.Panel StringPanel2;
    
    StringsGroup = new System.Windows.Forms.GroupBox();
    StingPanel = new System.Windows.Forms.Panel();
    StringPanel2 = new System.Windows.Forms.Panel();
    
    //Add your controls to StringPanel
    StingPanel.Size = new System.Drawing.Size(300, 800);
    StringPanel2.Size = new System.Drawing.Size(325, 345);
    StringPanel2.AutoScroll = true;
    
    this.StringPanel2.Controls.Add(StingPanel);
    this.StringsGroup.Controls.Add(this.StringPanel2);
