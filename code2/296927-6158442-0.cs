    public virtual void UpdateGraph(double[] xvals, double[] yvals, double minX, double maxX)
        {
            zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = false;
            zedGraphControl1.GraphPane.XAxis.Scale.MinAuto = false;
            zedGraphControl1.GraphPane.XAxis.Scale.Min = minX;
            zedGraphControl1.GraphPane.XAxis.Scale.Max = maxX;
            zedGraphControl1.GraphPane.YAxis.Scale.Min = 0;
            zedGraphControl1.GraphPane.YAxis.Scale.Max = getMax(yvals, xvals, minX, maxX);   //get y-value max within the X-value range
            updateZedgraphControl(xvals, yvals);
        }
    protected virtual void updateZedgraphControl(double[] xvals, double[] yvals)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.AddCurve(this.curveTitle, xvals, yvals, Color.Black, SymbolType.None);
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();
        }
