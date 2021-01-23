    //designer class
    // 
    // comboBox1
    // 
    this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
    this.comboBox1.DropDownHeight = 1;
    this.comboBox1.DropDownWidth = 1;
    this.comboBox1.FormattingEnabled = true;
    this.comboBox1.IntegralHeight = false;
    this.comboBox1.Location = new System.Drawing.Point(256, 371);
    this.comboBox1.Name = "comboBox1";
    this.comboBox1.Size = new System.Drawing.Size(238, 21);
    this.comboBox1.TabIndex = 5;
    this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
    this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
    // 
    // panel1
    // 
    this.panel1.BackColor = System.Drawing.Color.White;
    this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.panel1.Controls.Add(this.checkBox9);
    this.panel1.Controls.Add(this.checkBox8);
    this.panel1.Controls.Add(this.checkBox7);
    this.panel1.Controls.Add(this.checkBox6);
    this.panel1.Controls.Add(this.checkBox5);
    this.panel1.Controls.Add(this.checkBox4);
    this.panel1.Controls.Add(this.checkBox3);
    this.panel1.Controls.Add(this.checkBox2);
    this.panel1.Controls.Add(this.checkBox1);
    this.panel1.Location = new System.Drawing.Point(252, 394);
    this.panel1.Name = "panel1";
    this.panel1.Size = new System.Drawing.Size(245, 68);
    this.panel1.TabIndex = 6;
    // 
    // checkBox9
    // 
    this.checkBox9.AutoSize = true;
    this.checkBox9.Location = new System.Drawing.Point(162, 48);
    this.checkBox9.Name = "checkBox9";
    this.checkBox9.Size = new System.Drawing.Size(80, 17);
    this.checkBox9.TabIndex = 9;
    this.checkBox9.Text = "checkBox9";
    this.checkBox9.UseVisualStyleBackColor = true;
    // 
    // checkBox8
    // 
    this.checkBox8.AutoSize = true;
    this.checkBox8.Location = new System.Drawing.Point(162, 27);
    this.checkBox8.Name = "checkBox8";
    this.checkBox8.Size = new System.Drawing.Size(80, 17);
    this.checkBox8.TabIndex = 8;
    this.checkBox8.Text = "checkBox8";
    this.checkBox8.UseVisualStyleBackColor = true;
    // 
    // checkBox7
    // 
    this.checkBox7.AutoSize = true;
    this.checkBox7.Location = new System.Drawing.Point(162, 4);
    this.checkBox7.Name = "checkBox7";
    this.checkBox7.Size = new System.Drawing.Size(80, 17);
    this.checkBox7.TabIndex = 7;
    this.checkBox7.Text = "checkBox7";
    this.checkBox7.UseVisualStyleBackColor = true;
    // 
    // checkBox6
    // 
    this.checkBox6.AutoSize = true;
    this.checkBox6.Location = new System.Drawing.Point(82, 47);
    this.checkBox6.Name = "checkBox6";
    this.checkBox6.Size = new System.Drawing.Size(80, 17);
    this.checkBox6.TabIndex = 5;
    this.checkBox6.Text = "checkBox6";
    this.checkBox6.UseVisualStyleBackColor = true;
    // 
    // checkBox5
    // 
    this.checkBox5.AutoSize = true;
    this.checkBox5.Location = new System.Drawing.Point(82, 26);
    this.checkBox5.Name = "checkBox5";
    this.checkBox5.Size = new System.Drawing.Size(80, 17);
    this.checkBox5.TabIndex = 4;
    this.checkBox5.Text = "checkBox5";
    this.checkBox5.UseVisualStyleBackColor = true;
    // 
    // checkBox4
    // 
    this.checkBox4.AutoSize = true;
    this.checkBox4.Location = new System.Drawing.Point(82, 4);
    this.checkBox4.Name = "checkBox4";
    this.checkBox4.Size = new System.Drawing.Size(80, 17);
    this.checkBox4.TabIndex = 3;
    this.checkBox4.Text = "checkBox4";
    this.checkBox4.UseVisualStyleBackColor = true;
    // 
    // checkBox3
    // 
    this.checkBox3.AutoSize = true;
    this.checkBox3.Location = new System.Drawing.Point(3, 47);
    this.checkBox3.Name = "checkBox3";
    this.checkBox3.Size = new System.Drawing.Size(80, 17);
    this.checkBox3.TabIndex = 2;
    this.checkBox3.Text = "checkBox3";
    this.checkBox3.UseVisualStyleBackColor = true;
    // 
    // checkBox2
    // 
    this.checkBox2.AutoSize = true;
    this.checkBox2.Location = new System.Drawing.Point(4, 24);
    this.checkBox2.Name = "checkBox2";
    this.checkBox2.Size = new System.Drawing.Size(80, 17);
    this.checkBox2.TabIndex = 1;
    this.checkBox2.Text = "checkBox2";
    this.checkBox2.UseVisualStyleBackColor = true;
    // 
    // checkBox1
    // 
    this.checkBox1.AutoSize = true;
    this.checkBox1.Location = new System.Drawing.Point(4, 4);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new System.Drawing.Size(80, 17);
    this.checkBox1.TabIndex = 0;
    this.checkBox1.Text = "checkBox1";
    this.checkBox1.UseVisualStyleBackColor = true;
    
---
    
    public Form1()
    {
        InitializeComponent();
    	panel1.Visible =false;
    }
    
    
    private void comboBox1_DropDown(object sender, EventArgs e)
    {
        panel1.Visible = true;
    }
    private void comboBox1_DropDownClosed(object sender, EventArgs e)
    {
        panel1.Visible = false;
    }
