            var f2 = new Form2();
            f2.TopLevel = false;
            f2.FormBorderStyle =       System.Windows.Forms.FormBorderStyle.None;
            f2.Size = this.Size;
            f2.BringToFront();
            f2.Visible = true;
            this.Controls.Add(f2);
