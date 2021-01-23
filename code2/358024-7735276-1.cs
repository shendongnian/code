    private void pbPrecentage(ToolStripProgressBar pb)
    {
        int percent = (int)(((double)(pb.Value - pb.Minimum) /
        (double)(pb.Maximum - pb.Minimum)) * 100);
    
        using (Graphics gr = pb.ProgressBar.CreateGraphics())
        {
            //Switch to Antialiased drawing for better (smoother) graphic results
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.DrawString(percent.ToString() + "%",
                SystemFonts.DefaultFont,
                Brushes.Black,
                new PointF(pb.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                    SystemFonts.DefaultFont).Width / 2.0F),
                pb.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                    SystemFonts.DefaultFont).Height / 2.0F)));
        }
    }
