    public void UploadFile(Stream file_stream)
            {
                using (var output = File.Open("dest/for/image.jpg", FileMode.Create, FileAccess.ReadWrite))
                {
                    file_stream.CopyTo(output);
                }
            }
