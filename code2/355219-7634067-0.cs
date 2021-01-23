    var objToFind = new MyObject { id = 42, value = "" };
    int foundIndex = yourList.BinarySearch(objToFind, new MyObjectIdComparer());
    // ...
    public class MyObjectIdComparer : Comparer<MyObject>
    {
        public override int Compare(MyObject x, MyObject y)
        {
            // argument checking etc removed for brevity
            return x.id.CompareTo(y.id);
        }
    }
