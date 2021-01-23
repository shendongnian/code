    private void chartMain_PostPaint(object sender, ChartPaintEventArgs e)
        {
            try
            {
                if (chartMain.ChartAreas.FirstOrDefault(a=>a.Name == "Default") == null)
                    return;
                Graphics graph = e.ChartGraphics.Graphics;
                var day = Date.GetBoundaries(daySelectorMain.DateTimePickerDay.Value);
                var toDate = day.Item2; //it is maxdate value (max value of x axis)
                var centerY = (float)chartMain.ChartAreas["Default"].AxisY.ValueToPixelPosition(-80); //-80 is the min value of y (y axis)
                var centerX = (float)chartMain.ChartAreas["Default"].AxisX.ValueToPixelPosition(toDate.ToOADate());
                var origoY = (float)chartMain.ChartAreas["Default"].AxisY.ValueToPixelPosition(0);
                var origoX = (float)chartMain.ChartAreas["Default"].AxisX.ValueToPixelPosition(toDate.ToOADate());
                var radius = (float)(centerY - origoY) - 1;
                graph.DrawLine(System.Drawing.Pens.Blue,
                               new PointF(origoX, origoY),
                               new PointF(centerX, centerY));
                graph.FillEllipse(new SolidBrush(Color.White), centerX - radius, centerY - radius, radius * 2, radius * 2);
            }
            catch (System.Exception exc)
            {
                Debug.Assert(false, exc.Message);
            }
        }
