    public Class1(SPListItem item)
    {
         string ID = item[FieldId.AudienceTargeting] as string;
         string NewID = ID.Remove(36);
         Guid guid = new Guid(NewID);
         Audience siteAudience = audManager.GetAudience(guid);
    } 
