    var users = await users.Users().ToListAsync();
    char[] listOfAtoL = "ABCDEFGHIJKL".toCharArray();
    CategorizedByLetterUserDto cat = new CategorizedByLetterUserDto();
    foreach (User u in users.OrderBy(a => a.Name)) {
        listOfAtoL.Contains(char.ToUpper(u.Name.toCharArray()[0])) ? cat.AtoL.Add(new AtoL() {id = u.ID, Name = u.Name}) : cat.MtoZ.Add(new MtoZ() {id = u.ID, Name = u.Name});
    }
    return cat;
