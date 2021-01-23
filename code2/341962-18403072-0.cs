    public static IEnumerable<IServerOnlineCharacter> GetUpdated()
            {
                var context = DataContext.GetDataContext();
                return context.ServerOnlineCharacters.OrderBy(p => p.ServerStatus.ServerDateTime).GroupBy(p => p.RawName).Select(p => p.OrderByDescending(x => x.Id).Take(1).Single());
            }
