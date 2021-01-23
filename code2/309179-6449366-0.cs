    public static string GetTimeText(DateTime eventTime)
    {
            var span = (DateTime.Now - eventTime);
            if(span.TotalSeconds < 60 )
            {
                return string.Format("about {0} seconds ago", span.TotalSeconds);
            }
            if(span.TotalMinutes < 60)
            {
                return string.Format("about {0} minutes ago", span.TotalMinutes);
            }
            ...
    }
