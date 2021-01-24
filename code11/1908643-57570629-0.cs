        private void Chart1_PostPaint(object sender, ChartPaintEventArgs e)
        {
            if (e.Chart.ChartAreas.Count > 0) // I don't yet truly understand when this event occurs, 
                                              // so I got plenty of null references.
            {
                Graphics g = e.ChartGraphics.Graphics;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                Color minorGridColor = Color.Gainsboro;
                ChartArea area = e.Chart.ChartAreas[0];
                double aymin = area.AxisY.Minimum;
                double aymax = area.AxisY.Maximum;
                int y0 = (int)area.AxisY.ValueToPixelPosition(aymin);
                int y1 = (int)area.AxisY.ValueToPixelPosition(aymax);
                foreach (var label in chart1.ChartAreas[0].AxisX.CustomLabels)
                {
                    double xposition = area.AxisX.ValueToPixelPosition(Math.Pow(10, label.FromPosition + 0.1));
                    if (xposition > area.AxisX.ValueToPixelPosition(minMaxXY[0]) && xposition < area.AxisX.ValueToPixelPosition(minMaxXY[1]))
                    //this prevents drawing of lines outside of the chart area
                    {
                        int x = (int)xposition;
                        using (Pen dashed_pen = new Pen(Color.FromArgb(10, 0, 0, 0), 1))
                        {
                            dashed_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            g.DrawLine(dashed_pen, x, y0, x, y1);
                        
                        }
                    }
                }
            }
        }
