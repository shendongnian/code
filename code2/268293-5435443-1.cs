    private Button CreateButton()
    {
        private System.Windows.Forms.Button button1;
        this.button1.Location = new System.Drawing.Point(40, 294); // <-- change location for each
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(75, 23);
        this.button1.TabIndex = 14; // <-- increase tab index or remove this line
        this.button1.Text = "Button1";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        this.Controls.Add(this.button1);
        return button;
    }
