                if (double.TryParse(textBox1.Text, out origin)
             && double.TryParse(textBox4.Text, out channels))
            {
                textBox2.Text = (30.00 - (10 * Math.Log10(origin))).ToString("n2");
                if (double.TryParse(textBox2.Text, out tb2)
                {
                    textBox3.Text = (tb2 - (10 * Math.Log10(channels))).ToString("n2");
                }
            }
