    private string ConvertImageSource(int articleID, string content)
        {
            var imageCount = content.Split(new string[] { "img " }, StringSplitOptions.None).ToList().Count - 1;
            for(int i = 0; i < imageCount; i++)
            {
                content = content.Replace($"<!{i + 1}>", $"/Articles/ShowImage?articleID={ articleID }&imageID={i + 1}");
            }
            return content;
        }
