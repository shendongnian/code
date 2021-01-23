        private static bool hasSeenIntro;
        /// <summary>Will return false only the first time a user ever runs this.
        /// Everytime thereafter, a placeholder file will have been written to disk
        /// and will trigger a value of true.</summary>
        public static bool HasUserSeenIntro()
        {
            if (hasSeenIntro) return true;
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!store.FileExists(LandingBitFileName))
                {
                    // just write a placeholder file one byte long so we know they've landed before
                    using (var stream = store.OpenFile(LandingBitFileName, FileMode.Create))
                    {
                        stream.Write(new byte[] { 1 }, 0, 1);
                    }
                    return false;
                }
                hasSeenIntro = true;
                return true;
            }
        }
