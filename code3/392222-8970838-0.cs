    public string BiggestVersionUrl()
        {
            // find biggest version for downloading later
            string BiggestVersionUrl1 = string.Empty;
            var p = this.Photo;
            if (!string.IsNullOrEmpty(p.OriginalUrl))
                BiggestVersionUrl1 = p.OriginalUrl;
            else if (!string.IsNullOrEmpty(p.LargeUrl))
                BiggestVersionUrl1 = p.LargeUrl;
            else if (!string.IsNullOrEmpty(p.MediumUrl))
                BiggestVersionUrl1 = p.MediumUrl;
            else if (!string.IsNullOrEmpty(p.SmallUrl))
                BiggestVersionUrl1 = p.SmallUrl;
            return BiggestVersionUrl1;
        }
