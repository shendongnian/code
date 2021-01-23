    var ordinaryPropertyValue = new Catalog.Core.Entities.OrdinaryPropertyValue();
    var fileFile = Request.Files["File" + prop.Id];
    if (fileFile == null)
        continue;
    string pathFile = Server.MapPath("~/temp");
    string filenameFile = Path.GetFileName(fileFile.FileName);
    if (!string.IsNullOrEmpty(filenameFile))
    {
        fileFile.SaveAs(Path.Combine(pathFile, filenameFile));
        ordinaryPropertyValue.Value = Path.Combine(pathFile, filenameFile);
        instance.SetPropertyValue(prop.Id, ordinaryPropertyValue);
    }
