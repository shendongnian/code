    public partial class Form1 : Form {
        private void pnlClickOnMe_MouseClick(object sender, MouseEventArgs e) {
            Point mouseLocation = MousePosition;
            // get point of mouse relative to pnlClickOnMe
            Point pointYouAreInterestedIn = pnlClickOnMe.PointToClient(mouseLocation); 
            lblShowCoordinates.Text = string.Format("{0} - {1}", pointYouAreInterestedIn.X, pointYouAreInterestedIn.Y);
        }
        public Form1() {
            InitializeComponent();
        }
        
        #region designer
        private void InitializeComponent() {
            this.lblShowCoordinates = new System.Windows.Forms.Label();
            this.pnlClickOnMe = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            this.lblShowCoordinates.AutoSize = true;
            this.lblShowCoordinates.Location = new System.Drawing.Point(32, 18);
            this.lblShowCoordinates.Size = new System.Drawing.Size(35, 13);
            this.pnlClickOnMe.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlClickOnMe.Location = new System.Drawing.Point(31, 64);
            this.pnlClickOnMe.Size = new System.Drawing.Size(206, 152);
            this.pnlClickOnMe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlClickOnMe_MouseClick);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pnlClickOnMe);
            this.Controls.Add(this.lblShowCoordinates);
            this.ResumeLayout(false);
            this.PerformLayout();
    
        }
    
        #endregion
    
        private System.Windows.Forms.Label lblShowCoordinates;
        private System.Windows.Forms.Panel pnlClickOnMe;
    }
