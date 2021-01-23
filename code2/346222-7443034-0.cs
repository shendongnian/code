            string[] xval = { "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX", "ElementX" };
            for (int i = 0; i < xval.Length; i++)
            {
                Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(i + 0.5, i + 1.5, xval[i]);
                Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels[i].GridTicks = GridTickTypes.TickMark;
            }
             
            // second label row
            Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(0, 5.5, "Group1", 1, LabelMarkStyle.LineSideMark);
            Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(5.5, 12.5, "Group2", 1, LabelMarkStyle.LineSideMark);
            Chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(12.5, 21.5, "Group3", 1, LabelMarkStyle.LineSideMark);
