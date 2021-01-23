        // Sets the read-only value of a file.
        public static void SetFileReadAccess(string FileName, bool SetReadOnly)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(FileName);
            // Set the IsReadOnly property.
            fInfo.IsReadOnly = SetReadOnly;
        }
