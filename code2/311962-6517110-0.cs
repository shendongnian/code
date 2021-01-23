    interface ICoordinate<T> { T GetX(int idx); T GetY(int idx); }
    
    class PointRepresentation : ICoordinate<T> {
       PointTypeArrayOrWhatever a;
       T GetX(int idx) { return a.GetX; }
    }
    class MyAlgorithm {
       ICoordinate accessor;
       void Compute() {
           // do something with accessor.GetX();
       }
    }
