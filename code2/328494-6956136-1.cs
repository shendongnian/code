    bool allSame = !MyList.Select(item => item.MyMember)
                          .Where(x => !string.IsNullOrEmpty(x))
                          .Distinct()
                          .Skip(1)
                          .Any();
