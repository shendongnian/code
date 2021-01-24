    var query = from p1 in persons
                from p2 in persons
                where p1.id != p2.id
                   && ( ( p1.SSN != null && p1.SSN == p2.SSN && p1.Lastname == p2.Lastname )
                     || ( p1.Firstname == p2.Firstname && p1.Lastname == p2.Lastname
                       && p1.Birthdate != null && p1.Birthdate == p2.Birthdate ) )
                select new { person1_ID = p1.id, person2_ID = p2.id };
