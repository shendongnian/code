    public class GDriveFile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string WebViewLink { get; set; }
    }
----------
    public enum GDriveFileRole
    {
        Owner,
        Organizer,
        FileOrganizer,
        Writer,
        Commenter,
        Reader
    }
