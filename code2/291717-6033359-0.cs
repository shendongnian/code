    class Keys : IEquatable<Keys>
    {
        private IEnumerable<double?> _keys = Enumerable.Empty<double?>();
    
        public override int GetHashCode()
        {
            int hash = 23;
            foreach (var element in _keys)
            {
                hash = hash * 37 + element.GetValueOrDefault().GetHashCode();
            }
            
            return hash;
        }
        
        public bool Equals(Keys other)
        {
            if (other == null)
                return false;
                
            if (_keys.Count() != other._keys.Count())
                return false;
    
            for (int index = 0; index < _keys.Count(); index++)
            {
                if (_keys.ElementAt(index) != other._keys.ElementAt(index))
                    return false;
            }
            
            return true;
        }
        
        public Keys(double?[] data, int[] indexes)
        {
            var keys = new List<double?>();
            foreach (var index in indexes)
            {
                keys.Add(data[index]);
            }
            _keys = keys;
        }
    }
