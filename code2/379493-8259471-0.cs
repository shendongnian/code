        private void Main_Shown(object sender, EventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                progressBar1.Value = i;
                int percent = (int)(((double)(progressBar1.Value -progressBar1.Minimum) / (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
	            using (Graphics gr = progressBar1.CreateGraphics())
	            {
	                gr.DrawString(percent.ToString() + "%",  SystemFonts.DefaultFont, Brushes.Black, new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)));
	            }
                System.Threading.Thread.Sleep(200);
            }
        }
