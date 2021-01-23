    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
    response.Clear();
    response.AddHeader("Content-Type", "binary/octet-stream");
    response.AddHeader("Content-Disposition", "attachment; filename=nameofthefile.pdf; size=" + downloadBytes.Length.ToString());
    response.Flush();
    response.BinaryWrite(downloadBytes);
    response.Flush();
    response.End();
