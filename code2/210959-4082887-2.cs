    private string GetLookup(string value, string type)
    {
        var lookupKey = type + value;                        
        using (MySqlConnection mconn = new MySqlConnection(ConfigurationSettings.AppSettings["UnicornConnectionString_SELECT"]))
        {
            mconn.Open();
            lock (reportLookups)
            {
                if (reportLookups.ContainsKey(lookupKey))
                {
                    return reportLookups[lookupKey].ToString();
                }
                var value = GetLookupValue(type, value);
                reportLookups[lookupKey] = value;
                return value;
            }
        }
    }
    
    private string GetLookupValue(string type, string value)
    {
        switch (type)
        {
            case "ATTR_APPLICATIONNAME":
                return value == Guid.Empty.ToString() 
                    ? "Unknown"
                    : applicationManager.CanGetByGUID(value)
                        ? applicationManager.GetByGUID(value).Name
                        : string.Empty;
            case "ATTR_CITYNAME":
                return UMConstantProvider.UMConstantProvider.GetConstant<UMString64>(int.Parse(value), UMMetricsResourceLibrary.Enumerations.ConstantType.CITY_NAME, ref mconn);
            case "ATTR_COUNTRYNAME":
                return UMConstantProvider.UMConstantProvider.GetConstant<UMString2>(int.Parse(value), UMMetricsResourceLibrary.Enumerations.ConstantType.COUNTRY_NAME, ref mconn);
            case "ATTR_ITEMDURATION":
                if(mediaItemManager.CanGetMediaItemByGUID(value)) {
                    MediaItem mi = mediaItemManager.GetMediaItemByGUID(value);
                    if (mi.MediaItemTypeID == (int)MediaItemType.ExternalVideo || mi.MediaItemTypeID == (int)MediaItemType.ExternalAudio)
                    {
                        return mediaItemManager.GetMediaItemByGUID(value).ExternalDuration;
                    }
                    else
                    {
                        List<BinaryAsset> bins = fileSystemManager.GetBinaryAssetsByMediaItemGuid(value, mi.DraftVersion);
                        var durationasset = from d in bins
                                            where d.Duration != 0
                                            select d.Duration;
                        return durationasset.FirstOrDefault() ?? "0";
                    }
                }
                else 
                {
                    return string.Empty;
                }
            default:
                return string.Empty;
        }
    }
