            GraphPane myPane = zedGraphControl1.GraphPane;
            
            myPane.AddPieSlices(new double[] { 10, 25, 25, 40 }, new[] { "1", "2", "3", "4" });
            myPane.Legend.IsVisible = false;
            foreach (var x in myPane.CurveList.OfType<PieItem>())
                x.LabelType = PieLabelType.None; 
                
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
