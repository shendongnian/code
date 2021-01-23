        public void RandomNumber(int min, int max)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int num = r.Next(min, max);
            lblPickFive_1.Text = num.ToString();
            int num2 = r.Next(min, max);
            lblPickFive_2.Text = num2.ToString();
            int num3 = r.Next(min, max);
            lblPickFive_3.Text = num3.ToString();
            int num4 = r.Next(min, max);
            lblPickFive_4.Text = num4.ToString();
            int num5 = r.Next(min, max);
            lblPickFive_5.Text = num5.ToString();
        }
