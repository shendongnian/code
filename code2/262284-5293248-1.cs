        public void IncrementTime(int serial, string errorCode)
        {
            var matchObjects = _memObjects.Where(x => x.Serial == serial && x.ErrorCode == errorCode).ToList();
            
            matchObjects.ForEach(x => x.ModifedAt = x.ModifedAt.AddSeconds(
                                        matchObjects.Count(y => matchObjects.IndexOf(y) < matchObjects.IndexOf(x))
                                 ));
        }
