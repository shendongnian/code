    internal class SymbolObj : ZedGraph.GraphObj
    {
        private ZedGraph.Symbol symbol;
        public SymbolObj(ZedGraph.SymbolType type, Color color, PointF position, float size)
        {
            this.symbol = new ZedGraph.Symbol(type, color);
            this.symbol.Size = size;
            if((type== SymbolType.Plus || type == SymbolType.Star || type== SymbolType.HDash || type == SymbolType.XCross || type == SymbolType.VDash) && size >= 4)
                this.symbol.Border.Width = 3f;
            this.symbol.Fill.IsVisible = true;
            this.symbol.Fill.Color = color;
            this.Location.X = position.X;
            this.Location.Y = position.Y;
        }
        public SymbolObj(SymbolObj rhs)
            : base(rhs)
        {
            this.symbol = new Symbol(rhs.symbol);
        }
        public override void Draw(Graphics g, ZedGraph.PaneBase pane, float scaleFactor)
        {
            if (((GraphPane)pane).XAxis.Type == AxisType.Text)
            {
                if (Location.X > 0)
                {
                    var xx = new double[(int)Location.X];
                    var yy = new double[(int)Location.X];
                    for (int i = 0; i < Location.X; i++)
                    {
                        xx[i] = i;
                        yy[i] = double.NegativeInfinity;
                    }
                    yy[yy.Count() - 1] = Location.Y;
                    LineItem line = new LineItem("Symbol", xx, yy, symbol.Fill.Color, SymbolType.None);
                    symbol.Draw(g, (GraphPane)pane, line, scaleFactor, false);
                }
            }
            else
            {
                LineItem line = new LineItem("Symbol", new double[] { Location.X }, new double[] { Location.Y }, symbol.Fill.Color, SymbolType.None);
                symbol.Draw(g, (GraphPane)pane, line, scaleFactor, false);
            }
        }
        public override void GetCoords(ZedGraph.PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords)
        {
            shape = "point";
            coords = this.Location.X.ToString() + ", " + this.Location.Y.ToString();
        }
     }
