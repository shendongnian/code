    public class ArchiveService {
        public Stream ArchiveFiles(IEnumerable<IFormFile> files) {
            MemoryStream stream = new MemoryStream();
            using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true)) {
                foreach (IFormFile file in files) {
                    var entry = archive.CreateEntry(file.FileName, CompressionLevel.Fastest);
                    using (Stream target = entry.Open()) {
                        file.CopyTo(target);
                    }
                }
            }
            return stream;
        }
        public async Task<Stream> ArchiveFilesAsync(IEnumerable<IFormFile> files) {
            MemoryStream stream = new MemoryStream();
            using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true)) {
                foreach (IFormFile file in files) {
                    var entry = archive.CreateEntry(file.FileName, CompressionLevel.Fastest);
                    using (Stream target = entry.Open()) {
                        await file.OpenReadStream().CopyToAsync(target);
                    }
                }
            }
            return stream;
        }
    }
}
