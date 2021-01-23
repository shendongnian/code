    public partial class Form1 : Form {
        private void panel1_MouseClick(object sender, MouseEventArgs e) {
            Point pointYouAreInterestedIn = panel1.PointToClient(MousePosition); // point of mouse relative to panel1
            label1.Text = string.Format("{0} - {1}", pointYouAreInterestedIn.X, pointYouAreInterestedIn.Y);
        }
        public Form1() {
            InitializeComponent();
        }
        
        #region designer
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(31, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 152);
            this.panel1.TabIndex = 1;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
    
        }
    
        #endregion
    
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
