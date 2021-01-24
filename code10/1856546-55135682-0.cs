        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName = "")
        {
            var response = await DownloadFileFromDatabase(fileName);
            if (response.IsSuccessStatusCode)
            {
                System.Net.Http.HttpContent content = response.Content;
                var contentStream = await content.ReadAsStreamAsync();
                var audioArray = ReadFully(contentStream);
                return Ok(new { response = audioArray, contentType = "audio/wav", fileName });
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
