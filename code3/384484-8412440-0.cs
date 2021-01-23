    master = zedGraphDruck.MasterPane;
    master.GraphObjList.Clear();
    master.PaneList.Clear();
    GraphPane g = new GraphPane(gpr, titel, null, null);
    ...
    master.Add(g);
    zedGraphDruck.AxisChange();
    zedGraphDruck.Invalidate();
