    public static class Localization
    {
        private static bool metadataLoaded = false;
        private static List<string> available = new List<string>();
        // The 'Available' property returns null until the private list is ready
        public static List<string> Available => metadataLoaded ? available : null;
        private static async Task LoadMetaData()
        {
            // Add items to private 'available' list here
            // When the list is ready, set our field to 'true'
            metadataLoaded = true;
        }
    }
