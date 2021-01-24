    [HttpGet]
    [Route("GetMedia/")]
    public ActionResult<List<Media>> GetAll()
    {
        string[] files = Directory.GetFiles(this.config.Value.JSONFileDirectory);
        if (files.Length > 0)
        {
            try
            {
                var serializer = JsonSerializer.CreateDefault();
                return files.Select(f =>
                    {
                        using (var reader = new StreamReader(f))
                        using (var jsonReader = new JsonTextReader(reader))
                        {
                            return serializer.Deserialize<Media>(jsonReader);
                        }
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Could not parse JSON file.", e);
            }
        }
        else
        {
            return NotFound("No files were found in the catalog.");
        }
    }
