        /// Removes unneeded versions from a sharepoint list item
        /// </summary>
        /// <param name="item">The SPListItem that needs some versions removed</param>
        /// <param name="minVersions">The minimum number of versions to keep</param>
        /// <param name="savedVersions">A collection of important version labels (or null)</param>
        /// <returns>The number of versions deleted</returns>
        internal static int RemoveVersions(SPListItem item, int minVersions, ICollection<string> savedVersions)
        {
            //  Homework for the reader: validate the input arguments.
            //  if item is null, throw an ArgumentNullException
            //  if minVersions < 0 throw an ArgumentOutOfRangeException
            int deletedCount = 0;
            int i = minVersions;    // start looking for old versions after skipping minVersions
            while (i < item.Versions.Count)
            {
                SPListItemVersion itemVersion = item.Versions[i];
                string versionLabel = itemVersion.VersionLabel;
                if (!itemVersion.IsCurrentVersion &&    // Not "current" according to SharePoint (e.g. last-published major version, moderated version)
                    (savedVersions == null || !savedVersions.Contains(versionLabel)))  // not one of our "saved" versions
                {
                    itemVersion.Delete();
                    ++deletedCount;
                }
                else
                {
                    ++i;
                }
            }
            return deletedCount;
        }
