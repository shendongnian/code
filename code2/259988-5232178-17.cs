    var newList = list
        .GroupBy(x => new {x.School, x.Friend, x.FavoriteColor})
        .Select(y => new ConsolidatedChild()
            {
                FavoriteColor = y.Key.FavoriteColor,
                Friend = y.Key.Friend,
                School = y.Key.School,
                Children = y.ToList()
            }
        );
