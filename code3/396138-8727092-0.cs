    public class MyComparer : IEqualityComparer<DataRow>
        {
            public bool Equals(DataRow x, DataRow y) {
                return x["col1"] == y.["col1"] && x["col2"] == y.["col2"];
            }
    
            public int GetHashCode(DataRow obj) {
                return obj["col1"].GetHashCode() ^ obj["col2"].GetHashCode();
            }
        }
