    [Route("Folders/ViewContent/{siteName}/{*folderNames}")]
    public async Task<IActionResult> ViewContent(string siteName, string folderNames)
    {
        folderNames = folderNames ?? "";
        string[] folders = folderNames.Split('/', StringSplitOptions.RemoveEmptyEntries);
         // your other code
    }
