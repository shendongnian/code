    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Painter
    {
        public partial class Form2 : Form
        {
            public System.Windows.Forms.Timer movementTimer;
            public Form2()
            {
                InitializeComponent();
                movementTimer = new System.Windows.Forms.Timer();
                movementTimer.Interval = 10;
                movementTimer.Tick += tick;
                movementTimer.Start();
                this.Invalidate();
                this.Update();
                this.Refresh();
            }
            void tick(object sender, EventArgs e)
            {
                this.Invalidate();
                this.Update();
                this.Refresh();
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                // I cannot hit breakpoint here.
                Console.WriteLine("PAINT METHOD HAS BEEN EXECUTED");
            }
            private void InitializeComponent()
            {
                this.SuspendLayout();
                // 
                // Form2
                // 
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Name = "Form2";
                this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
                this.ResumeLayout(false);
            }
    
        }
    }
