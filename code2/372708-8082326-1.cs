        public static bool IsReadOnly(string file)
        {
            return (File.GetAttributes(file) & FileAttributes.ReadOnly) ==
                    FileAttributes.ReadOnly;
        }
        public static void SetNonReadOnlyAttributes(string file)
        {
            try
            {
                FileAttributes attrs = File.GetAttributes(file);
                File.SetAttributes(file, attrs & ~FileAttributes.ReadOnly);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format(
                        "Error setting non-readonly attributes to file {0}: {1}",
                        file, ex.Message));
            }
        }
