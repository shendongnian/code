        private void button1_Click(object sender, EventArgs e)
        {
            receive.Text = send.Text;
            Size sz = new Size(receive.ClientSize.Width, int.MaxValue);
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            int padding = 3;
            int borders = receive.Height - receive.ClientSize.Height;
            sz = TextRenderer.MeasureText(receive.Text, receive.Font, sz, flags);
            int h = sz.Height + borders + padding;
            if (receive.Top + h > this.ClientSize.Height - 10)
            {
                h = this.ClientSize.Height - 10 - receive.Top;
            }
            receive.Height = h;
        }
