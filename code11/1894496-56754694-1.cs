        private string GetDayUrl(DateTime date)
        {
            return _linkGenerator.GetPathByAction("GetDay", "Home", date);
        }
 
