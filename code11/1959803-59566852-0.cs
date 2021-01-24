csharp
var userslistQuery = 
     (from USZipCode in _db.USZipCodes                     
     where SqlFunctions.SquareRoot(.....) <= 25
     join User in _db.Users on USZipCode.ZipCode equals User.ZipCode
     select User).Take(10000);
var x = (from user in userslistQuery 
             where (user.Ethnicity == Ethnicity) &&
             (user.Sex == Gender) &&
             (user.HasProfilePhoto == HasProfilePic) 
            select new SearchResultsViewModel
            {
              _userid = user.UserID,
              _username = user.UserName,                                  
              _sex = user.Sex,
              _city = user.City,
              _state = user.State,
            }).Take(800).ToList();
Just use the query, not the resultant `List`.
