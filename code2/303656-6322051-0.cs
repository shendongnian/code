    string dir = Request.Form("dir");
    if (string.IsNullOrEmpty(dir))
    	dir = "/";
    
    if (Session["Logged_User"] == null)
    {
    	Response.Write("Not Authorized");
    	Response.End();
    }
    
    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Server.MapPath(dir));
    StringBuilder sb = new StringBuilder();
    sb.Append("<ul class=\"jqueryFileTree\" style=\"display: none;\">").Append(Environment.NewLine);
    foreach (System.IO.DirectoryInfo di_child in di.GetDirectories())
    {
    	sb.AppendFormat("\t<li class=\"directory collapsed\"><a href=\"#\" rel=\"{0}\">{1}</a></li>\n",  dir + di_child.Name, di_child.Name);
    }
    
    foreach (System.IO.FileInfo fi in di.GetFiles())
    {
    	string ext = (fi.Extension.Length > 1) ? fi.Extension.Substring(1).ToLower() : "";
    	sb.AppendFormat("\t<li class=\"file ext_{0}\"><a href=\"#\" rel=\"{1}\">{2}</a></li>\n", ext, dir + fi.Name, fi.Name);
    }
    sb.Append("</ul>");
    Response.Write(sb.ToString());
