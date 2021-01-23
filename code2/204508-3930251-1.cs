    using (var de = myUser.GetUnderlyingObject() as DirectoryEntry)
    {
        if (de != null)
        {
           // Go for those attributes and do what you need to do...
           var mobile = de.Properties["mobile"].Value as string;
           var info = de.Properties["info"].Value as string;
        }
    }
