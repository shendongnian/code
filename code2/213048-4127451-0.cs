    HttpPostedFileBase file = Request.Files["CoverUpload"];
    cover.CoverMimeType = file.ContentType;
    cover.CoverFileName = Path.GetFileName(file.FileName);
    cover.FileID = int.Parse(Request.Form["FileID"]);
    byte[] input = new byte[file.ContentLength];
    using (Stream s = file.InputStream)
    {
        s.Read(input, 0, file.ContentLength);
    }
    cover.CoverFileContent = input;
    filerepository.AddCoverData(cover);
    filerepository.Save();
    return View(cover);
