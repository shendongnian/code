    public static class SecurityExtensions
    {
        public static IQueryable<DocumentFolder> WhereCanSeeFolder(
            this IQueryable<DocumentFolder> folders)
        {
            return folders
                .Where(CanSeeFolder)
                .Where(CanSeeFoldersOwner);
        }
        private static readonly Expression<Func<DocumentFolder, bool>>
            CanSeeFolder = folder => !folder.IsPrivate;
        private static readonly Expression<Func<DocumentFolder, bool>>
            CanSeeFoldersOwner = folder => !folder.Owner.IsPrivate;
    }
