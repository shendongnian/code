    // Mock 3rd Party point
    public class ThirdPartyPoint {
    }
    // Mock 3rd party line
    public class ThirdPartyLine {
        public ThirdPartyPoint StartPoint { get; set; }
        public ThirdPartyPoint EndPoint { get; set; }
    }
    
    // This class implements IEqualityComparer<ThirdPartyLine>, which compares
    // ThirdPartyLine's equality. THis class will be passed as a ctor arument to HashSet<T>
    public class CompareLines : IEqualityComparer<ThirdPartyLine> {
        public bool Equals(ThirdPartyLine x, ThirdPartyLine y) {
            // Here check for the equality of the start and end points.
            // I asuumed the following but do not know how the eaulity is implemented in your library.
            return x.EndPoint == y.EndPoint && x.StartPoint == y.StartPoint;
        }
        public int GetHashCode(ThirdPartyLine obj) {
            // Implement an algortihm which must return same hashcode for objects considered the same.
            // I am not sure about the Point class hashcode but I am jsut assuming the following.
            return obj.StartPoint.GetHashCode() ^ obj.EndPoint.GetHashCode();
        }
    }
    private static void Main(string[] args) {
            // Hashset to hold lines
            var hashSet = new HashSet<ThirdPartyLine>(new Compare());
            // start point
            var starPoint = new ThirdPartyPoint();
            // end point
            var endPoint = new ThirdPartyPoint();
            
            // Lines with same start and end points
            var line1 = new ThirdPartyLine {
                StartPoint = starPoint,
                EndPoint = endPoint
            };
            var line2 = new ThirdPartyLine {
                StartPoint = starPoint,
                EndPoint = endPoint
            };
            
            
            // Check count first
            hashSet.Add(line1);
            var count = hashSet.Count;
            
            // Check count second, still 1
            hashSet.Add(line2);
            count = hashSet.Count;
        }
