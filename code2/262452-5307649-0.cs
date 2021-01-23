    private void RunMessagePump()
            {            
                Application.Run(new TimeZoneForm.TimeZoneForm());
            }
    internal class TimeZoneForm : Form
        {
            public TimeZoneForm()
            {
                InitializeComponent();
            }
    
            private void TimeZoneForm_Load(object sender, EventArgs e)
            {
                SystemEvents.TimeChanged += SystemEvents_TimeChanged;            
            }
    
            private void TimeZoneForm_Closing(object sender, FormClosingEventArgs e)
            {
                SystemEvents.TimeChanged -= SystemEvents_TimeChanged;            
            }
    
            private void SystemEvents_TimeChanged(object sender, EventArgs e)
            {
                System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
            }
    
            private System.ComponentModel.IContainer components = null;
    
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            private void InitializeComponent()
            {
                this.SuspendLayout();
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(0, 0);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Name = "TimeZoneForm";
                this.Text = "TimeZoneForm";
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                this.Load += this.TimeZoneForm_Load;
                this.FormClosing += this.TimeZoneForm_Closing;
                this.ResumeLayout(false);
    
            }
        }
