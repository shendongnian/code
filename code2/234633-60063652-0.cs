public void DownloadTeamPhoto(string fileName)
{
  string mimeType = MimeAssistance.GetMimeFromRegistry(fileName);
  Response.ContentType = mimeType;
  Response.AppendHeader("Content-Disposition", "attachment; filename=" + 
  Path.GetFileName(basePath + fileName)); //basePath= @"~/Content/
  Response.WriteFile(basePath + fileName); //basePath= @"~/Content/
  Response.End();
			
}
public static string GetMimeFromRegistry(string Filename)
{
  string mime = "application/octetstream";
  string ext = System.IO.Path.GetExtension(Filename).ToLower();
  Microsoft.Win32.RegistryKey rk = 
  Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
   
  if (rk != null && rk.GetValue("Content Type") != null)
	 mime = rk.GetValue("Content Type").ToString();
		
  return mime;
}
