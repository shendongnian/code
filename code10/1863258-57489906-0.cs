          Paths subj = new Paths(1);
          subj.Add(new Path());
          subj[0].Add(new IntPoint(0, 0));
          subj[0].Add(new IntPoint(440, 280));
          subj[0].Add(new IntPoint(440, 0));
          subj[0].Add(new IntPoint(0, 280));
          subj[0].Add(new IntPoint(440 / 2, 280));
          subj[0].Add(new IntPoint(440 / 2, 0));
          GraphicsPath gpEllipse = new GraphicsPath();
          Rectangle r = new Rectangle(40,40,360,360);
          gpEllipse.AddEllipse(r);
          gpEllipse.Flatten();
          Paths clip = new Paths(1);
          clip.Add(new Path());
          foreach (PointF p in gpEllipse.PathPoints)
            clip[0].Add(new IntPoint(p.X, p.Y));
          Clipper c = new Clipper();
          c.AddPaths(subj, PolyType.ptSubject, false);
          c.AddPaths(clip, PolyType.ptClip, true);
          Paths solution = new Paths();
          PolyTree solutiontree = new PolyTree();
          c.Execute(ClipType.ctIntersection, solutiontree, 
            PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
          solution = Clipper.OpenPathsFromPolyTree(solutiontree);
          //nb: you'll find SVGBuilder in SVG.cs in the sample code accompanying Clipper
          SVGBuilder svg = new SVGBuilder();
          svg.AddPaths(subj, Color.White, Color.Black, false);
          svg.AddPaths(clip, Color.FromArgb(0x18, 0xFF, 0xFF, 0), Color.Black, true);
          svg.PenWidth = 2.5;
          svg.AddPaths(solution, Color.White, Color.Red, false);
          svg.SaveToFile("c:\\temp\\test.svg", 640, 480, 20);
