    public static class SecurityExtensions
    {
        public static IQueryable<DocumentFolder> WhereCanSeeFolder(
            this IQueryable<DocumentFolder> folders)
        {
            var visibleOwners = folders.Select(f => f.Owner)
                .Where(CanSeePerson);
            return
                from folder in folders.Where(CanSeeFolder)
                where visibleOwners.Contains(folder.Owner)
                select folder;
        }
        private static readonly Expression<Func<DocumentFolder, bool>>
            CanSeeFolder = folder => !folder.IsPrivate;
        private static readonly Expression<Func<Person, bool>>
            CanSeePerson = person => !person.IsPrivate;
    }
