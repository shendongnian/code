        int currentY;
        bool isDragging = false;
        private void OnDrag(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                //calculate Y position relative to parent
                int parentY = this.Top + e.Y;
                if (parentY < currentY)
                {
                    if (parentY > 158 && parentY >= 148)
                    {
                        if (this.Top != 148)
                        {
                            currentY += (this.Top - 148);
                            this.Top = 148;
                        }
                    }
                    else if (parentY < 148 /*&& parentY >= 138*/)
                    {
                        if (this.Top != 138)
                        {
                            currentY += (this.Top - 138);
                            this.Top = 138;
                        }
                    }
                    //And so on
                }
                else if (parentY > currentY)
                {
                    if (/*parentY <= 158 &&*/ parentY >= 148)
                    {
                            currentY += (this.Top - 158);
                            this.Top = 158;
                    }
                    else if (parentY < 148 && parentY >= 138)
                    {
                            currentY += (this.Top - 148);
                            this.Top = 148;
                    }
                    //And so on
                }
            }
        }
        public void MusicNote_MouseDown(object sender, MouseEventArgs e)
        {
            currentY = this.Top + e.Y;
            this.Capture = true;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isDragging = true;
            }
            this.MouseMove += new MouseEventHandler(OnDrag);
        }
        public void MusicNote_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            this.Capture = false;
            this.MouseMove -= new MouseEventHandler(OnDrag);
        }
