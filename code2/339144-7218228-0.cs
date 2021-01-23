        var data = 
            from tv in r.Root.Descendants("programme")
            where tv.Attribute("channel").Value == "1201"
            let channelE1 = tv.Attribute("channel")
            let startE1 = tv.Attribute("start")
            let nameEl = tv.Element("title")
            orderby tv.Attribute("start").Value ascending
            let urlEl = tv.Element("desc")
            let guide = new TV1guide
            {
                DisplayName = nameEl == null ? null : nameEl.Value,
                ChannelName = channelE1 == null ? null : channelE1.Value,
                ChannelURL = urlEl == null ? null : urlEl.Value,
                StartTime = startE1 == null ? (DateTimeOffset?)null : ParseDate(startE1.Value),
            }
            where DateTimeOffset.Now.AddHours(-2) <= guide.StartTime && guide.StartTime <= DateTimeOffset.Now.AddDays(1)
            select guide;
    }
    private static DateTimeOffset ParseDate(string value)
    {
        return  DateTimeOffset.ParseExact(value, "yyyyMMddHHmmss zzz", DateTimeFormatInfo.CurrentInfo);
    }
