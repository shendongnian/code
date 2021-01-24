    // a few references:
    ChartArea ca = chart.ChartAreas[0];
    Axis ax = ca.AxisX;
    Axis ay = ca.AxisY;
    // create an annotation
    var ra = new RectangleAnnotation();
    // by default anotations are positioned in percentages
    // we associate it with axes to change positioning to axis values:
    ra.AxisX = ax;
    ra.AxisY = ay;
    // our colors:
    ra.LineColor = Color.White;
    // for testing I use a semi-transparent color:
    ra.BackColor = Color.FromArgb(222, Color.White);
    // the values of the last point in my series:
    double vxLast = chart.Series[0].Points.Last().XValue;
    double vyLast = chart.Series[0].Points.Last().YValues[0];
    // the top right of the chartarea:
    double vxEnd = ax.Maximum;
    double vyEnd = ay.Maximum;
    // we position the annotation
    ra.X = vxLast;
    ra.Y = vyEnd;
    // by default annotations are as large as we set them to be
    // I cheat by clipping it to my chartarea:
    ra.ClipToChartArea = ca.Name;
    // now it is enough to make them really large:
    ra.Width = 9999;
    ra.Height = 9999;
    // done. now we show it:
    chart.Annotations.Add(ra);
