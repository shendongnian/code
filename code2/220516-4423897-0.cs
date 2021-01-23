         using ZedGraph;
         ...
         GraphPane myPane = zg1.GraphPane; // zg1 is a ZedGraph control.
         // Set the title and axis label
         myPane.Title.Text = "Stacked Bar, ZedGraph ver 5.1.5.28844";
         myPane.YAxis.Title.Text = "Value";
         // Create two dates.
         XDate date1 = new XDate(2010, 11, 28); // First date.
         XDate date2 = new XDate(2010, 11, 29); // Second date.
         
         // Create data lists and bars for A, B, C, Back, Body and Arm (6 total).
         ZedGraph.PointPairList listA = new ZedGraph.PointPairList();
         listA.Add( date1, 12 );
         listA.Add( date2, 13);
         BarItem barA = zg1.GraphPane.AddBar("A", listA, Color.Red );
         barA.Bar.Fill = new Fill( Color.Red );
         ZedGraph.PointPairList listB = new ZedGraph.PointPairList();
         listB.Add(date1, 12);
         listB.Add(date2, 12);
         BarItem barB = zg1.GraphPane.AddBar("B", listB, Color.Blue);
         barB.Bar.Fill = new Fill(Color.Blue);
         ZedGraph.PointPairList listC = new ZedGraph.PointPairList();
         listC.Add(date1, 13);
         listC.Add(date2, 12);
         BarItem barC = zg1.GraphPane.AddBar("C", listC, Color.Green);
         barC.Bar.Fill = new Fill(Color.Green);
         ZedGraph.PointPairList listBack = new ZedGraph.PointPairList();
         listBack.Add(date1, 122);
         listBack.Add(date2, 122);
         BarItem barBack = zg1.GraphPane.AddBar("Back", listBack, Color.Red);
         barBack.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);
         ZedGraph.PointPairList listBody = new ZedGraph.PointPairList();
         listBody.Add(date1, 112);
         listBody.Add(date2, 112);
         BarItem barBody = zg1.GraphPane.AddBar("Body", listBody, Color.Blue);
         barBody.Bar.Fill = new Fill(Color.Blue, Color.White, Color.Blue);
         ZedGraph.PointPairList listArm = new ZedGraph.PointPairList();
         // listArm.Add(date1, 0); // Not needed for XAxis.Type = AxisType.Date.
         listArm.Add(date2, 20);
         BarItem barArm = zg1.GraphPane.AddBar("Arm", listArm, Color.Green);
         barArm.Bar.Fill = new Fill(Color.Green, Color.White, Color.Green);
         // Done creating bars.
         myPane.BarSettings.Type = BarType.Stack;  // stacks bar rather than side-by-side.
         myPane.BarSettings.ClusterScaleWidth = 1; // Widen bars somewhat.
         // Format the X axis.
         XAxis x = myPane.XAxis;
         x.Type = AxisType.Date;
         x.Scale.Format = "yyyy-mm-dd";
         x.Scale.BaseTic = date1; // Puts the first major tic at the first date.
         x.Scale.Min = date1 - 0.5; // Manually set the left of the graph window just prior to the first date.
         x.Scale.Max = date2 + 0.5; // Manually set the right of the graph window just after the last date.
         // Setting the step size...
         // Isn't required if AxisType.Date is DateAsOrdinal.
         // Docs says that MinorStep is ignore for AxisType.Date but seems inaccurate.
         // Step value of 24 was derived by trial and error. Seems it should be 1 if Unit = DateUnit.Day.
         // A value of 24 implies that the Units are acting like DateUnit.Hour.
         x.Scale.MajorUnit = DateUnit.Day; 
         x.Scale.MinorUnit = DateUnit.Day;
         x.Scale.MinorStep = 24; 
         x.Scale.MajorStep = 24;
         zg1.AxisChange(); // Update graph.
