    sealed class DataComparer : IEqualityComparer<Data>
    {
        public bool Equals(Data x, Data y)
        {
            return x.Serial.Equals(y.Serial);
        }
        public int GetHashCode(Data obj)
        {
            return obj.Serial.GetHashCode();
        }
    }
