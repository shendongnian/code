            var feedCodes = new string[] { "9051245", "9051246", "9051247", "9051245", "9031454", "9021447" };
            
            var mostOccuring = feedCodes.Where(feedCode => feedCode != null)
                .GroupBy(feedCode => feedCode.Length < 3 ? feedCode : feedCode.Substring(0, 3))
                .OrderByDescending(group => group.Count())
                .FirstOrDefault();
            if(mostOccuring==null)
            {
                //some exception handling
            }
            else
            {
                //process mostoccuring.Key
            }
