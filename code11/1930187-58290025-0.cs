        [HttpGet("[action]")]
        public async Task<FileResult> ExportExtraAsync(int id)
        {
            // get file details in db
            var toDownload = await unitOfWork.ExtrasRepository.GetByIdAsync(id);
           // build a file path
            IFileProvider provider = new PhysicalFileProvider(Path.GetDirectoryName(toDownload.FileDirectory));
            IFileInfo fileInfo = provider.GetFileInfo(Path.GetFileName(toDownload.FileDirectory));
            var readStream = fileInfo.CreateReadStream();
            // return a file stream, this will force the browser to download
            return File(readStream, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(toDownload.FileDirectory));
        }
