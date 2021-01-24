    private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            int temp;
            if (e.Y < label1.Height / 2)
                { if (int.TryParse(label1.Text, out temp))
                    label1.Text = (temp += 1).ToString();}
            else
            {
                if (int.TryParse(label1.Text, out temp))
                    label1.Text = (temp -= 1).ToString();
            }
        }
