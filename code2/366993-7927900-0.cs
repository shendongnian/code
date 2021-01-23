    var result = (from shareclass in database.ShareClassInfo
        where shareclass.Id == ID
        select new ShareClass
                   {
                       IsOnlineListing = shareclass.IsOnlineListing.HasValue ?
                           shareclass.IsOnlineListing.Value : false;
                   }
       );
    var list = result.ToList();
