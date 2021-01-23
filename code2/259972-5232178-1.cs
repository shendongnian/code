    var newList = list.GroupBy(x => new {x.School, x.Friend, x.FavoriteColor})
                        .Select(x => new ConsolidatedChild()
                                            {
                                                FavoriteColor = x.Key.FavoriteColor,
                                                Friend = x.Key.Friend,
                                                School = x.Key.School,
                                                Children = x.ToList()
                                            }
                        );
