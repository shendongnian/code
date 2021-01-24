    public class CoordinateUtil
    {
        private readonly IEdgeCaseDetector edgeCaseDetector;
    
        // This is the important bit where you inject an edge case detector
        public CoordinateUtil(IEdgeCaseDetector edgeCaseDetector)
        {
            this.edgeCaseDetector = edgeCaseDetector;
        }
    
        public IEnumerable<Coordinate> RayCast(Coordinate source, Coordinate direction)
        {
            if (direction.X == 0 || direction.Y == 0)
            {
                edgeCaseDetector.Detect("Orthogonal_Edge_Case");
                //Simple iteration across 1 axis
                yield break;
            }
            if (Math.Abs(direction.X) == Math.Abs(direction.Y))
            {
                edgeCaseDetector.Detect("Diagonal_Edge_Case");
                //Simple diagonal iteration
                yield break;
            }
    
            //Standard Bresenham's algorithm
            yield break;
        }
    }
    public interface IEdgeCaseDetector
    {
        void Detect(string message);
    }
    public class EdgeCaseDetector
    {
        public void Detect(string message)
        {
           // If you wanted to you could simply save the edge cases to a public property here
           // Or you might want to log them when you code runs outside of the unit test
        }
    }
    [TestClass]
    public class CoordinateUtilTests
    {
        [TestMethod]
        public void RayCast_WhenOthogonal_DetectsEdgeCase()
        {
            // Arrange
            var mock = new Mock<IEdgeCaseDetector>();
            var coordinateUtil = new CoordinateUtil(mock.Object);
            var source = new Coordinate(1, 1);
            // Act
            // Remember the ToArray because we need to evaluate the enumerable
            // before we can check if the edge case was detected.
            coordinateUtil.RayCast(source, new Coordinate(0, 0)).ToArray();
            // Assert
            mock.Verify(x => x.EdgeDetected("Orthogonal_Edge_Case"));
        }
    }
