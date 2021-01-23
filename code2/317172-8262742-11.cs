    FileAttachment[] attachments = null;
    var index = BuildCidIndex(sHTMLCOntent);
    if (index.Count > 0 && item.Attachments.Count > 0)
    {
        var basePath = Directory.GetCurrentDirectory();
      
        attachments = new FileAttachment[item.Attachments.Count];
        for (var i = 0; i < item.Attachments.Count; ++i)
        {
          var type = item.Attachments[i].ContentType.ToLower();
          if (!type.StartsWith("image/")) continue;                    
          type = type.Replace("image/", "");
          var attachment = (FileAttachment)item.Attachments[i];
          var cid = attachment.ContentId;
          var filename = cid + "." + type;
          var path = Path.Combine(basePath, filename);
          if(ReplaceCid(index, ref sHTMLCOntent, cid, path))
          {
             // only load images when they have been found          
             attachment.Load(path);
             attachments[i] = attachment;
          }
       }
    }
