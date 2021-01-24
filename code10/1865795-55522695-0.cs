    private readonly MyConfig conf;
    //Constructor
    public AnnouncementService(MyConfig config) {
        this.conf = config;
    }
    private async Task<string> SaveAnnouncement(IFormFile file = null, string base64 = null) {
        string path = conf.FolderAnnouncement;
        string imageUrl = Guid.NewGuid().ToString();
        var mediaPath = conf.BaseMediaUrl;
        string extension = Path.GetExtension(file.FileName);
        var imagePath = mediaPath + path + imageUrl+extension;
        if (!string.IsNullOrEmpty(base64)) {
            byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(imagePath, bytes);  
        } else {
            using (var fileStream = new FileStream(imagePath, FileMode.Create)) {
                await file.CopyToAsync(fileStream);
            }
        }
        return  imageUrl+extension;
    }
