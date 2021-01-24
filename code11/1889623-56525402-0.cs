    List<Hashtag> hashTags = new List<Hashtag>();
    // var hashTag = new Hashtag(); remove this line move it to inside foreach
    
    Regex expression = new Regex(@"([#][a-zA-Z0-9]{1})\w*");
    var results = expression.Matches(model.Caption);
    foreach (Match match in results)
    {
       /*Keep it here so every time a new instance of Hashtag will be created and cached in your hasTags list,
      instead of updating same reference and adding it again, which causes your issue */
      var hashTag = new Hashtag();
      hashTag.CreatedOn = DateTime.UtcNow;
      hashTag.Id = Guid.NewGuid();
      hashTag.Text = match.ToString();
    
      hashTags.Add(hashTag);
    }
    
    db.Hashtags.AddRange(hashTags);
    await db.SaveChangesAsync();
