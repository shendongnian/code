    ZedGraph.LineItem neueKurve = new LineItem("+1", ppl, Color.Blue, SymbolType.None);
    ZedGraph.LineItem neueKurve1 = new LineItem("+2", ppl1, Color.Green, SymbolType.None);
    neueKurve.Line.StepType = StepType.ForwardSegment;
    neueKurve.Line.Fill.Type = FillType.Brush;
    neueKurve.Line.Fill.Brush = SystemBrushes.Info;
    neueKurve1.Line.StepType = StepType.RearwardSegment;
    zedGraphControl1.GraphPane.CurveList.Add(neueKurve);
    zedGraphControl1.GraphPane.CurveList.Add(neueKurve1);
