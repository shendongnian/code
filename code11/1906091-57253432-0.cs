    collectionOne = collectionOne
                        .Where(filter)
                        .Select(item =>
                            {
                                item.collectionTwo = collectionTwo.Where(filter);
                                return item;
                            });
