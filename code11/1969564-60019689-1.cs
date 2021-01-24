        private void button1_Click(object sender, EventArgs e)
        {
            int res = 0;
            if (double.TryParse(costot.Text, out double costot) && double.TryParse(unidadesp.Text, out double unidadesp) && unidadesp != 0)
            {
                res = (int)(Math.Round(costot / unidadesp));
                costou.Text = res.ToString();
            }
        }
