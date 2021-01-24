            private void calculate_btn_Click(object sender, EventArgs e)
            {
                var sourceList = new List<TimeSpan>();
                TimeSpan timeSpan;
                if (TimeSpan.TryParse(textBox1.Text, out timeSpan)) {
                  sourceList.Add(timeSpan);
                }
                if (TimeSpan.TryParse(textBox2.Text, out timeSpan)) {
                  sourceList.Add(timeSpan);
                }
                if (TimeSpan.TryParse(textBox3.Text, out timeSpan)) {
                  sourceList.Add(timeSpan);
                }
                var averageTimeSpan = new TimeSpan(Convert.ToInt64(sourceList.Average(x => x.Ticks)));
                averagelabletext.Text = averageTimeSpan.ToString();
            }
