        DateTime dt1 = DateTime.Parse("5/1/2011");
        DateTime dt2 = DateTime.Parse("5/14/2011");
        private void button1_Click(object sender, EventArgs e)
        {
            int NumberDays = (int) dt2.Subtract(dt1).TotalDays;
            MessageBox.Show(NumberDays.ToString());
        }
