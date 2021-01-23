        public class Segment
        {
            public Point From { get; set; }
            public Point To { get; set; }
        }
        public class ViewModel
        {
            public IList<Segment> Segments { get; set; }
        }
        void SetDataContext()
        {
            var Points = new Point[]
            {
                new Point { X = 0, Y = 10 },
                new Point { X = 10, Y = 30 },
                new Point { X = 20, Y = 20 },
            };
            DataContext = new ViewModel
            {
                Segments = new List<Segment>(Points.Zip(Points.Skip(1), (a, b) => new Segment { From = a, To = b }))
            };
        }
