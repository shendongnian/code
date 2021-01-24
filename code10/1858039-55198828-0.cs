    [HttpGet("{id}")]
    public ActionResult Get(Guid id)
    {
        var files = Directory.GetFiles(@"Pictures\");
        foreach (var file in files)
        {
            if (file.Contains(id.ToString()))
            {
                return File(System.IO.File.ReadAllBytes(file), "image/jpeg");
            }
        }
        return null;
    }
