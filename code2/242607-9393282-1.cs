        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((int)MdiChildren.GetLength(0) > 0)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }
