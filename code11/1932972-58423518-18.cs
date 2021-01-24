    public class SpatialIndexMorton {
        SortedList<ulong, List<ICoordinate>> orderedData;
        List<ulong> orderedIndexes;
    
        public SpatialIndexMorton(IEnumerable<ICoordinate> data) {
            orderedData = data.GroupBy(d => d.MortonCode()).ToSortedList(g => g.Key, g => g.ToList());
            orderedIndexes = orderedData.Keys.ToList();
        }
    
        public ICoordinate FindNearest(ICoordinate aPoint) {
            var mc = aPoint.MortonCode();
            var nearestIndex = orderedIndexes.FindNearestIndex(mc);
            var nearestGuess = orderedData.Values[nearestIndex][0];
            var guessDist = (nearestGuess.Longitude - aPoint.Longitude) * (nearestGuess.Longitude - aPoint.Longitude) + (nearestGuess.Latitude - aPoint.Latitude) * (nearestGuess.Latitude - aPoint.Latitude);
            if (nearestIndex > 0) {
                var tryGuess = orderedData.Values[nearestIndex-1][0];
                var tryDist = (tryGuess.Longitude - aPoint.Longitude) * (tryGuess.Longitude - aPoint.Longitude) + (tryGuess.Latitude - aPoint.Latitude) * (tryGuess.Latitude - aPoint.Latitude);
                if (tryDist < guessDist) {
                    nearestGuess = tryGuess;
                    guessDist = tryDist;
                }
            }
    
            var offsetPOI = new PointOfInterest(guessDist, guessDist);
            var minmc = (aPoint.Minus(offsetPOI)).MortonCode();
            var minmci = orderedIndexes.FindNearestIndex(minmc);
            if (minmci > 0)
                --minmci;
            var maxmc = (aPoint.Plus(offsetPOI)).MortonCode();
            var maxmci = orderedIndexes.FindNearestIndex(maxmc);
            for (int j2 = minmci; j2 < maxmci; ++j2) {
                var tryList = orderedData.Values[j2];
                for (int j3 = 0; j3 < tryList.Count; ++j3) {
                    var y = tryList[j3];
                    var ydist = (y.Longitude - aPoint.Longitude) * (y.Longitude - aPoint.Longitude) + (y.Latitude - aPoint.Latitude) * (y.Latitude - aPoint.Latitude);
                    if (ydist < guessDist) {
                        nearestGuess = y;
                        guessDist = ydist;
                    }
                }
            }
    
            return nearestGuess;
        }
    }
