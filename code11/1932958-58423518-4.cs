    public class SpatialIndex {
        SortedList<ulong, List<ICoordinate>> orderedData;
        List<ulong> orderedIndexes;
    
        public SpatialIndex(IEnumerable<ICoordinate> data) {
            orderedData = data.GroupBy(d => d.HilbertIndex()).ToSortedList(g => g.Key, g => g.ToList());
            orderedIndexes = orderedData.Keys.ToList();
        }
    
        public ICoordinate FindNearest(ICoordinate aPoint) {
            var mc = aPoint.HilbertIndex();
            var nearestGuess = orderedData.Values[orderedIndexes.FindNearestIndex(mc)][0];
            var guessDist = aPoint.DistanceTo(nearestGuess);
            var offsetPOI = new PointOfInterest(guessDist, guessDist);
            var minmc = (aPoint.Minus(offsetPOI)).HilbertIndex();
            var minmci = orderedIndexes.FindNearestIndex(minmc);
            var maxmc = (aPoint.Plus(offsetPOI)).HilbertIndex();
            var maxmci = orderedIndexes.FindNearestIndex(maxmc);
            for (int j2 = minmci; j2 < maxmci; ++j2) {
                var tryList = orderedData.Values[j2];
                for (int j3 = 0; j3 < tryList.Count; ++j3) {
                    var y = tryList[j3];
                    var ydist = ((y.Longitude - aPoint.Longitude) * (y.Longitude - aPoint.Longitude) + (y.Latitude - aPoint.Latitude) * (y.Latitude - aPoint.Latitude));
                    if (ydist < guessDist) {
                        nearestGuess = y;
                        guessDist = ydist;
                    }
                }
            }
            return nearestGuess;
        }
    }
