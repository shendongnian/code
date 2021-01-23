        public static bool IsReadOnly(string file)
        {
            bool result = (File.GetAttributes(file) & FileAttributes.ReadOnly) ==
                           FileAttributes.ReadOnly;
            return result;
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
