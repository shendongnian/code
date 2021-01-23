            static void Sort(List<CollectionsItem> list)
            {
                list.Sort((p1, p2) =>
                    {
                        if (int.Parse(p1.ObjectId) == int.Parse(p2.ObjectId))
                            return 0;
                        else if (int.Parse(p2.ObjectId) > int.Parse(p1.ObjectId))
                            return 1;
                        else
                            return -1;
                    });
            }
