        public Form1()
        {
            this.Load += new System.EventHandler(this.Form1_Load);
        }
        public System.Windows.Controls.TextBox textBox6 = new System.Windows.Controls.TextBox();
        public ElementHost sumtext = new ElementHost();
        private System.Windows.Forms.GroupBox groupBox4;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(57, 63);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(591, 238);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 478);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            textBox6.Name = "Summary";
            textBox6.FontFamily = new System.Windows.Media.FontFamily("Microsoft Sans Serif");
            textBox6.FontSize = 12;
            textBox6.SpellCheck.IsEnabled = true;
            groupBox4.Controls.Add(sumtext);
            sumtext.Dock = DockStyle.None;
            sumtext.Width = 246;
            sumtext.Height = 35;
            sumtext.Child = textBox6;
            sumtext.Location = new Point(3, 33);
            sumtext.Visible = true;
            sumtext.Enabled = true;
            groupBox4.Controls.Add(sumtext);
        }
