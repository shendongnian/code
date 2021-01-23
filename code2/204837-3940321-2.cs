        private void button1_Click(object sender, EventArgs e)
        {
            //Read some values in a contrived example to get a mixture of null 
            //and not null values into t1, t2 & t3
            decimal? t1 = null;
            decimal? t2 = null;
            decimal? t3 = null;
            decimal res = 0;
            decimal tt1 = 0;
            decimal tt2 = 0;
            decimal tt3 = 0;
            if (decimal.TryParse(textBox1.Text, out tt1))
                t1 = tt1;
            if (decimal.TryParse(textBox2.Text, out tt2))
                t2 = tt2;
            if (decimal.TryParse(textBox3.Text, out tt3))
                t3 = tt3;
            
            //We have setup our inputs now, so lets get down to how to handle the problem                    
            //now.  This should probably be in a separate function, but we are in a _Click 
            //method, so I am assuming we are overlooking such things in this example...
            //return without setting textBox4 if any of t1, t2 & t3 are null
            if (!t1.HasValue || !t2.HasValue || !t2.HasValue)
            {
                return;
            }           
            //1, 2 & 3 are all valid, so set textBox4
            res = Math.Abs(t1.Value + t2.Value - t3.Value);
            textBox4.Text = res.ToString();
       }
