        private System.Windows.Forms.GroupBox grpDR;//GROUPBOX IN WHICH PANEL WILL OVERLAY
    private System.Windows.Forms.Panel grpScrlDR;//PANEL WHICH WILL HAVE SCROLL BAR AND CONTAIN CHECK BOXES
    
    private System.Windows.Forms.CheckBox chkDr2;
    private System.Windows.Forms.CheckBox chkDr1;
    
     private void InitializeComponent()
    {
      this.grpScrlDR = new System.Windows.Forms.Panel();
      this.chkDr2 = new System.Windows.Forms.CheckBox();
      this.chkDr1 = new System.Windows.Forms.CheckBox();
      this.grpDR = new System.Windows.Forms.GroupBox();
    
      this.grpScrlDR.SuspendLayout();
      this.grpDR.SuspendLayout();
    
    
    // 
    // grpScrlDR
    // PANEL DETAILS ADDING CHECKBOX CONTROLS AND ENABLING AUTO SCROLL
      this.grpScrlDR.AutoScroll = true;
      this.grpScrlDR.Controls.Add(this.chkDr2);
      this.grpScrlDR.Controls.Add(this.chkDr1);
      this.grpScrlDR.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grpScrlDR.Location = new System.Drawing.Point(5, 336);
      this.grpScrlDR.Name = "grpScrlDR";
      this.grpScrlDR.Size = new System.Drawing.Size(175, 230);
      this.grpScrlDR.TabIndex = 0;
    
    // 
    // chkDr2
    // 
      this.chkDr2.AutoSize = true;`
      this.chkDr2.Location = new System.Drawing.Point(13, 45);
      this.chkDr2.Name = "chkDr2";
      this.chkDr2.Size = new System.Drawing.Size(54, 20);
      this.chkDr2.TabIndex = 1;
      this.chkDr2.Text = "Permit#";
      this.chkDr2.UseVisualStyleBackColor = true;
      this.chkDr2.CheckedChanged += new System.EventHandler(this.chkDr_CheckedChanged);
    
    // 
    // chkDr1
    // 
      this.chkDr1.AutoSize = true;
      this.chkDr1.Checked = true;
      this.chkDr1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkDr1.Location = new System.Drawing.Point(13, 22);
      this.chkDr1.Name = "chkDr1";
      this.chkDr1.Size = new System.Drawing.Size(54, 20);
      this.chkDr1.TabIndex = 0;
      this.chkDr1.Text = "Account";
      this.chkDr1.UseVisualStyleBackColor = true;
      this.chkDr1.CheckedChanged += new System.EventHandler(this.chkDr_CheckedChanged);
    
    // 
    // grpDR
    // GROUP BOX DETAILS - GROUP BOX IS ADDING PANEL CONTROLS
      this.grpDR.Controls.Add(this.grpScrlDR);
      this.grpDR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    
      this.grpDR.Location = new System.Drawing.Point(5, 336);
      this.grpDR.Name = "grpDR";
      this.grpDR.Size = new System.Drawing.Size(175, 230);
      this.grpDR.TabIndex = 46;
      this.grpDR.TabStop = false;
      this.grpDR.Text = "Report by";
      this.grpDR.Visible = false;
    }
