    var duplicates = new List<Tuple<int, int>>();
    foreach ( var p1 in persons )
      foreach ( var p2 in persons )
        if ( p1.id != p2.id
          && ( ( p1.SSN != null && p1.SSN == p2.SSN && p1.Lastname == p2.Lastname )
            || ( p1.Firstname == p2.Firstname && p1.Lastname == p2.Lastname
              && p1.Birthdate != null && p1.Birthdate == p2.Birthdate ) ) )
          if ( !duplicates.Contains(new Tuple<int, int>(p2.id, p1.id)) )
            duplicates.Add(new Tuple<int, int>(p1.id, p2.id));
