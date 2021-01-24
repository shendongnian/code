    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace SoExamples.Rotation
    {
        public  class Form1 : Form
        {
            Bitmap bmp = new Bitmap(100, 100); //placeholder... our rotating box
            Point p1 = new Point(80,5);//a point in our rotating box
            int deg = 0;//the current rotation of the box in degrees 0...359
            Point start;//a point to start drawing a line...
    
    
            public Form1()
            {
                InitializeComponent();
    
                //preparing our dummy box
                using (var graphics = Graphics.FromImage(bmp))
                {
                    graphics.Clear(Color.LightBlue);// a background color...
                    graphics.DrawString("X", DefaultFont, Brushes.White, p1);
                }
    
                //calculating the start point for a line...
                start = new Point(label1.Location.X + label1.Width / 2, label1.Location.Y + label1.Height); //in the middle under the label
            }
            /// <summary>
            /// timer handler, executed every time the timer is ellapsed ... every 100ms
            /// </summary>
            private void timer1_Tick(object sender, EventArgs e)
            {
                deg++;//let's rotate...
                deg %= 360;//0...359
                Invalidate(true);//queue for re-drawing
            }
    
            /// <summary>
            /// custom painting for the Form ... called every time the form is re-drawn
            /// </summary>
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                var g = e.Graphics;
    
                g.Clear(BackColor);
    
                Point drawTo = new Point(Width / 2, Height / 2);//we want to draw the box in the center of the form
                drawTo.Offset(-bmp.Width / 2, -bmp.Height / 2);//...but we need to specify the upper left corner
    
                Point rotateAround = new Point(Width / 2, Height / 2);//we want to rotate the box around the center
    
                g.TranslateTransform(-rotateAround.X, -rotateAround.Y); //translate the rotateAround point as 0,0
                g.RotateTransform(-deg, System.Drawing.Drawing2D.MatrixOrder.Append);//rotate
                g.TranslateTransform(rotateAround.X, rotateAround.Y, System.Drawing.Drawing2D.MatrixOrder.Append);//translate back
    
                g.DrawImageUnscaled(bmp, drawTo);//draw the box with respect to current transforms... 
    
                g.ResetTransform();//now back to our original coordinate-space
    
                var P = new Point(drawTo.X + p1.X, drawTo.Y + p1.Y); //the point we want to point to in the original coordinate-space (before rotation)
    
                var O = rotateAround;
                var rad = deg * Math.PI / 180d; //System.Math want's our angle in radians 
    
                //coordinate calculation for a rotation around O
                //PT_x = (P_x - O_x) * cos(d) + (P_y - O_y) * sin(d) + O_x
                //PT_y = -(P_x - O_x) * sin(d) + (P_y - O_y) * cos(d) + O_y
    
                var PT_x = (P.X - O.X) * Math.Cos(rad) + (P.Y - O.Y) * Math.Sin(rad) + O.X;
                var PT_y = -(P.X - O.X) * Math.Sin(rad) + (P.Y - O.Y) * Math.Cos(rad) + O.Y;
    
                drawTo = new Point((int)PT_x, (int)PT_y);
    
                g.DrawLine(Pens.Black, start, drawTo); // draw a line to the calculated point
    
            }
    
            //boiler plate code follows...
    
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
                this.components = new System.ComponentModel.Container();
                this.label1 = new System.Windows.Forms.Label();
                this.timer1 = new System.Windows.Forms.Timer(this.components);
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(41, 43);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(197, 13);
                this.label1.TabIndex = 1;
                this.label1.Text = "Some fixed point to start drawing a line to the top left corner of a 'X' in a rotating box...";
                // 
                // timer1
                // 
                this.timer1.Enabled = true;
                this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(800, 450);
                this.Controls.Add(this.label1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Timer timer1;
        }
    }
