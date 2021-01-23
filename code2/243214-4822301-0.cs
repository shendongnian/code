        public FileResult Thumbnail()
        {
            // TODO: insert image loading/resizing code here...
            
            // The response type
            var ct = "image/png";
            
            var ms = new MemoryStream(byteArray);
            return new FileStreamResult(ms, ct);
        }
