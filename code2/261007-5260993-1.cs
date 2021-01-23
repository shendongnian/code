    private class DataColumnComparer : IEqualityComparer<DataColumn>
        {
            #region IEqualityComparer<DataColumn> Members
            public bool Equals(DataColumn x, DataColumn y)
            {
                return x.Caption == y.Caption;
            }
            public int GetHashCode(DataColumn obj)
            {
                return obj.Caption.GetHashCode();
            }
            #endregion
        }
        private class ObjectArrayComparer : IEqualityComparer<object[]>
        {
            #region IEqualityComparer<object[]> Members
            public bool Equals(object[] x, object[] y)
            {
                for (var i = 0; i < x.Length; i++)
                {
                    if (!object.Equals(x[i], y[i]))
                        return false;
                }
                return true;
            }
            public int GetHashCode(object[] obj)
            {
                return obj.Sum(item => item.GetHashCode());
            }
            #endregion
        }
