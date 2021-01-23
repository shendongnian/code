    private static void Chart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            Chart c = ((Chart)sender);
            foreach (Series s in c.Series)
            {
                string sVt = s.GetCustomProperty("PixelPointWidth");
                IGanttable ig = (IGanttable)s.Tag;
                double dblPixelWidth = c.ChartAreas[0].AxisY.ValueToPixelPosition(s.Points[0].YValues[1]) - c.ChartAreas[0].AxisY.ValueToPixelPosition(s.Points[0].YValues[0]);
                
                s.Label = ig.Text.AutoEllipsis(s.Font, Convert.ToInt32(dblPixelWidth)-dblSeriesPaddingGuess);
            }
        }
    public static string AutoEllipsis(this String s, Font f, int intPixelWidth)
        {
            if (s.Length == 0 || intPixelWidth == 0) return "";
            
            var result = Regex.Split(s, "\r\n|\r|\n");
            List<string> l = new List<string>();
            foreach(string str in result)
            {
                int vt = TextRenderer.MeasureText(str, f).Width;
                if (vt < intPixelWidth)
                { l.Add(str); }
                else
                {
                    string strTemp = str;
                    int i = str.Length;
            
                    while (TextRenderer.MeasureText(strTemp + "…", f).Width > intPixelWidth)
                    {
                        strTemp = str.Substring(0, --i);
                        if (i == 0) break;
                    }
                    l.Add(strTemp + "…");
                }
            }
            return String.Join("\r\n", l);
            
        }
