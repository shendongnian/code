      ScrollBar vScroller = new VScrollBar();
            private void Form1_Load(object sender, EventArgs e)
            {
            
                vScroller.Dock = DockStyle.Right;
                vScroller.Width = 30;
                vScroller.Height = this.Height;
                vScroller.BackColor = Color.Black;
                vScroller.Scroll += new System.Windows.Forms.ScrollEventHandler(vScroller_Scroll);
                this.VerticalScroll.Visible = false;
                this.VerticalScroll.Enabled = false;
                this.Controls.Add(vScroller);
    
    
            }
            private void vScroller_Scroll(object sender, ScrollEventArgs e)
            {
                this.VerticalScroll.Value = e.NewValue;
            }
