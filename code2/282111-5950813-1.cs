        /// <summary>  
        /// Adds item to archive  
        /// </summary>  
        /// <param name="item">Item to add</param>  
        /// <param name="destination">Archive path</param>  
        /// <param name="destination">web site of archive</param>  
        /// <returns>Result of arhivation process</returns>  
        public static string ArchiveItem(SPListItem item, string destination, SPWeb web)
        {
            // Save main meta information for later use:  
            var author = item.File.Author;
            var modifiedBy = item.File.ModifiedBy;
            var modified = item.File.TimeLastModified;
            var created = item.File.TimeCreated;
            // Get destination filename:  
            var destinationFile = destination + "/" + item.File.Name;
            // Copy the item and set properties:  
            var coppiedFile = web.GetFolder(destination).Files.Add(
                destinationFile,
                item.File.OpenBinary(),
                author,
                modifiedBy,
                created,
                modified
            );
            coppiedFile.Item["Created"] = created;
            coppiedFile.Item["Modified"] = modified;
            // Save changes, UpdateOverwriteVersion causes object to save without saving a new version.
            coppiedFile.Item.UpdateOverwriteVersion();
            // If moving is enabled, delete original item:  
            item.Delete();
            return coppiedFile.ServerRelativeUrl;
        }
