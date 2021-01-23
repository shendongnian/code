    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public class Form1 : Form
        {
            private static List<Rectangle> rectangles = new List<Rectangle> {
                //            x,y,w,h
                new Rectangle(0,0,10,10),
                new Rectangle(10,10,10,10),
                new Rectangle(10,40,10,10),
                new Rectangle(60,20,10,10),
                new Rectangle(90,10,10,10),
            };
            private Label label1;
            private RectanglePictureBox rectPicBox1;
            public Form1() {
                InitializeComponent();
                this.rectPicBox1.Rectangles = rectangles;
            }
            private void rectPicBox1_Click(object sender, EventArgs e) {
                if ( rectangles.Count <= 0 ) {
                    Console.Beep(); // nothing left to remove!
                } else {
                    rectangles.RemoveAt(rectangles.Count - 1);
                    rectPicBox1.Rectangles = rectangles;
                }
            }
            #region InitializeComponent (Modified Manually)
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent() {
                this.rectPicBox1 = new WindowsFormsApplication1.RectanglePictureBox();
                this.label1 = new System.Windows.Forms.Label();
                ((System.ComponentModel.ISupportInitialize)(this.rectPicBox1)).BeginInit();
                this.SuspendLayout();
                // 
                // rectPicBox1
                // 
                this.rectPicBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.rectPicBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
                this.rectPicBox1.Location = new System.Drawing.Point(1, 1);
                this.rectPicBox1.Name = "rectPicBox1";
                this.rectPicBox1.Size = new System.Drawing.Size(257, 131);
                this.rectPicBox1.TabIndex = 0;
                this.rectPicBox1.TabStop = false;
                this.rectPicBox1.Click += new System.EventHandler(this.rectPicBox1_Click);
                // 
                // label1
                // 
                this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(2, 138);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(254, 13);
                this.label1.TabIndex = 1;
                this.label1.Text = "Clicking on the picture to removes the last rectangle.";
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(259, 156);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.rectPicBox1);
                this.Name = "Form1";
                this.Text = "Rectangles";
                ((System.ComponentModel.ISupportInitialize)(this.rectPicBox1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            #endregion
            #region Component Model
            private System.ComponentModel.IContainer components = null;
            protected override void Dispose(bool disposing) {
                if ( disposing && (components != null) ) {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            #endregion
        }
        ////////////////////////////////////////////////////////////////////////////
        class RectanglePictureBox : PictureBox
        {
            public static Color[] _colors = { 
                Color.Red, Color.Green, Color.Blue, Color.Orange 
            };
            public List<Rectangle> Rectangles {
                set { Image = ImageOf(value); }
            }
            private Bitmap ImageOf(List<Rectangle> rectangles) {
                Bitmap result = new Bitmap(Size.Height, Size.Width);
                Graphics graphics = Graphics.FromImage(result);
                for ( int i = 0; i < rectangles.Count; ++i ) {
                    Brush brush = new SolidBrush(_colors[i % _colors.Length]);
                    graphics.FillRectangle(brush, rectangles[i]);
                }
                return result;
            }
        }
    }
