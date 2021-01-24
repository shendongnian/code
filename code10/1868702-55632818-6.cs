        public class TriangleFactory: GeometricFigureFactory
        {
            public override GeometricFigure Create()
            {
                return new Triangle();
            }
        }
