    //opecations in tempList , LINQ to Entities; so we can not use class types in select only anonymous types are allowed
    var tempList = dbQuery.Skip(10).Take(10).ToList();// this is list of <anonymous type> so we have to convert it so list of <letter>
    
    //opecations in list , LINQ to Object; so we can use class types in select
    list = tempList.Select(l => new Letter{ Title = l.Title, ID = l.ID, LastModificationDate = l.LastModificationDate, DateCreated = l.DateCreated, LetterStatus = new LetterStatus{ ID = l.LetterStatus.ID, NameInArabic = l.LetterStatus.NameInArabic, NameInEnglish = l.LetterStatus.NameInEnglish } }).ToList();
                                    ^^^^^^ with type 
