    var query = (from p in PBZGdb.Instance.AuthenticationDatas
                     where p.Username == "Misha" && p.Password == "123"
                     select new { p.UserAccount }).AsEnumerable();
    UserAccount UA = query.ElementAt(0).UserAccount; //this works!
    var count = UA.Characters.Count(); //throws InvalidCastException here
