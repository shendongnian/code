        public IStation GetStationIndex(IStation s)
        {
            var index = _stations.IndexOf(s);
            if (index == -1)
            {
               throw new ArgumentException();
            }
            var isLast = index == _stations.Count -1;
            if (isLast)
            {
                return null;
            }
            return _stations[index + 1];
        }
    
    
        public string GetLineDirection(Station from, Station to, Line commonLine)
        {
           var direction = commonLine.GetStationIndex(from)<=commonLine.GetStationIndex(to)?"next" : "previous" 
           return direction;
        }
