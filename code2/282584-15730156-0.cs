    public photos FindRandomUserPhoto(string userlogin)
    {
       return FindUserPhotos(userlogin).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
    }
    
    public Array<photos> Find10RandomUserPhotos(string userlogin)
    {
       var result = New Array<photos>;
       for (i = 0; i < 10; i++) {
          result.add(FindRandomUserPhoto(userlogin));
       }
       return result
    }
