    var info = new FileInfo(Server.MapPath(path));
    Response.Clear();
    Response.AppendHeader("Content-Disposition", String.Concat("attachment; filename=", info.Name));
    Response.AppendHeader("Content-Length", info.Length.ToString(CultureInfo.InvariantCulture));
    Response.ContentType = type;
    Response.WriteFile(info.FullName, true);
    Response.End();
