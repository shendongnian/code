    var Selecteduser = results.Where(x => x.Name == selectedname && x.ID == ID).ToList();
    if (Selecteduser.Count != 0)
    {
        //found match ..(Selecteduser[0])
        string selectedcourse = Selecteduser[0].Course;
        int selectedgrade = Selecteduser[0].Grade;
    }
    else
    {
       //coudlnt find match
    }
