        private void button_Click(object sender, EventArgs e)
        {
            int j = 100;
            for (int i = 0; i < j; i++)
            {
                Thread.Sleep(5);
                label3.Location = new System.Drawing.Point(0 + i, 111);
                label3.Visible = true;
               
            }
            for (int i = j; i-- > 0; )
            {
                Thread.Sleep(15);
                label3.Location = new System.Drawing.Point(0 + i, 111);
                label3.Visible = true;
                if (i < 1)
                    button_Click(sender, e);
            }
        }
