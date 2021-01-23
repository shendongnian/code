    public photos FindRandomUserPhoto(string userlogin)
    {
       var qry = FindUserPhotos(userlogin);
       int count = qry.Count();
       int index = new Random().Next(count);
       return qry.Skip(index).FirstOrDefault();
    }
    public Array<photos> Find10RandomUserPhotos(string userlogin)
    {
       var result = New Array<photos>;
       for (i = 0; i < 10; i++) {
          result.add(FindRandomUserPhoto(userlogin));
       }
       return result
    }
