        private void graph2()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            // clearing not tested
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.BarSettings.Type = BarType.PercentStack;
            //      myPane.XAxis.Type = ZedGraph.AxisType.Date;
            // Date wont work in our case
            PointPairList PPLa = new PointPairList();
            PointPairList PPLb = new PointPairList();
            PointPairList PPLc = new PointPairList();
            PointPairList PPLd = new PointPairList();
            PointPairList PPLf = new PointPairList();
            List<int> listA = new List<int>();
            List<int> listB = new List<int>();
            List<int> listC = new List<int>();
            List<int> listD = new List<int>();
            List<int> listF = new List<int>();
            //listA = getIntA();
            //listB = getIntB();
            //listC = getIntC();
            //listD = getIntD();
            //listF = getIntF();
            for (int i = 0; i < 5; i++)
            {
                listA.Add(i);
                listB.Add(i + 1);
                listC.Add(i);
            }
            // above is used to fill up the lists (for example)
            // when you us < instead of <= you dont need a listA.Count - 1
            for (int i = 0; i < listA.Count; i++)
            {
                PPLa.Add(i, (double)listA[i]);
                PPLb.Add(i, (double)listB[i]);
                PPLc.Add(i, (double)listC[i]);
                PPLd.Add(i, (double)listA[i]);
                PPLf.Add(i, (double)listB[i]);
            }
            // dragged drawing baritems out of forloop
            BarItem myBara = myPane.AddBar("A", PPLa, Color.Red);
            BarItem myBarb = myPane.AddBar("B", PPLb, Color.Blue);
            BarItem myBarc = myPane.AddBar("C", PPLc, Color.Gray);
            BarItem myBard = myPane.AddBar("D", PPLd, Color.Black);
            BarItem myBarf = myPane.AddBar("F", PPLf, Color.Pink);
            zedGraphControl1.AxisChange();
        }
