    // It's good practice create extensions methods in the same namespace of the class to extend
    namespace System.Windows.Forms {
        public static class SaveFileDialogFileTypeExtension {
            // Retrieving only text of the file extensions
            private static List<string> GetFileExtensions(string filter) {
                List<string> extensions = new List<string>();
                var filtersRaw = filter.Split('|');
                for (int i = 0; i < filtersRaw.Length; i++) {
                    if (i % 2 != 0) {
                        // Supporting multi doted extensions
                        extensions.Add(filtersRaw[i].Trim().Replace("*", "").Substring(1));
                    }
                }
                return extensions;
            }
            // Getting filename with selected extension
            public static string FileNameForceExtension(this SaveFileDialog dialog) {
                string fileName = dialog.FileName;
                // Retrieving the current selected filter index
                List<string> extensions = GetFileExtensions(dialog.Filter);
                string selectedExtension = extensions[dialog.FilterIndex - 1];
                // Adding extension if need it
                if (!fileName.EndsWith($".{selectedExtension}")) {
                    fileName = $"{fileName}.{selectedExtension}";
                }
                return fileName;
            }
        }
    }
