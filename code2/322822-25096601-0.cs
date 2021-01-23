        `public static void DeleteDirectoryRecursive(string directory, IsolatedStorageFile store)
        {
            if (!store.DirectoryExists(directory))
                return;
            var pattern = Path.Combine(directory, "*");
            foreach (var file in store.GetFileNames(pattern))
            {
                store.DeleteFile(Path.Combine(directory, file));
            }
            foreach (var folder in store.GetDirectoryNames(pattern))
            {
                 DeleteDirectoryRecursive(Path.Combine(directory, folder), store);
            }
            store.DeleteDirectory(directory);
        }`
