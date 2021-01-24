           TimeSpan sum = new TimeSpan();
            for (int i=0;i< IdleList.Count; i++)
            {
                sum += TimeSpan.Parse(IdleList[i]);
            }
        
