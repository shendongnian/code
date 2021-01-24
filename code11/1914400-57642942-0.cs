        public async Task<string> GetLyrics()
        {
            var file = await StorageFile.GetFileFromPathAsync(Path);
            using (var stream = await file.OpenAsync(FileAccessMode.Read))
            {
                using (var mp3 = new Mp3(stream.AsStream()))
                {
                    var lyrics = mp3.GetTag(Id3TagFamily.Version2X).Lyrics;
                    return lyrics.Count > 0 ? lyrics[0].Lyrics : "";
                }
            }
        }
