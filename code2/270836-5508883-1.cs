    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class FakeComboBox : ComboBox {
        private PictureBox fake;
        public new bool Enabled {
            get { return base.Enabled; }
            set { if (!this.DesignMode) displayFake(value);
                  base.Enabled = value;
            }
        }
        private void displayFake(bool enabled) {
            if (!enabled) {
                fake = new PictureBox();
                fake.Location = this.Location;
                fake.Size = this.Size;
                var bmp = new Bitmap(fake.Size.Width, fake.Size.Height);
                this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                fake.Image = bmp;
                this.Parent.Controls.Add(fake);
                fake.BringToFront();
                fake.Click += delegate { Console.Beep(); };
            }
            else {
                this.Parent.Controls.Remove(fake);
                fake.Dispose();
                fake = null;
            }
        }
    }
