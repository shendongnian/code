    public class LinkToDocument
    {
      
       public static readonly Guid g_guidIconOverride = new Guid("{B77CDBCF-5DCE-4937-85A7-9FC202705C91}");
       public static readonly string FLD_URL = "URL";
      
       /// <param name="name">file name</param>
       /// <param name="urlVal">Url del link</param>
       /// <param name="overrideIcon">file extension for the file icon</param>
       public static SPListItem CreateLinkToDocumentFile(SPDocumentLibrary list, string name, SPFieldUrlValue urlVal, string overrideIcon = null)
       {
          var docType = list.ContentTypes.Cast<SPContentType>().Single(ct => ct.Id.IsChildOf(SPBuiltInContentTypeId.LinkToDocument));
          return CreateLinkToDocumentFile(list, docType.Id, name, urlVal, overrideIcon);
       }
      
       public static SPListItem CreateLinkToDocumentFile(SPDocumentLibrary list, SPContentTypeId contentTypeId, string name, SPFieldUrlValue urlVal, string overrideIcon = null)
       {
          SPContentType contentType = list.ContentTypes[contentTypeId];
          string extension = "";
          if (urlVal != null && urlVal.Url != null) extension = Path.GetExtension((urlVal.Url).Trim()).TrimStart(".".ToCharArray());
          SPFolder currentFolder = list.RootFolder;
          SPFileCollection files = currentFolder.Files;
          string fileUrl = string.Concat(currentFolder.Url, "/", name, ".aspx");
          string fileTemplate = "<%@ Assembly Name='{0}' %>\r\n <%@ Register TagPrefix='SharePoint' Namespace='Microsoft.SharePoint.WebControls' Assembly='Microsoft.SharePoint' %>\r\n <%@ Import Namespace='System.IO' %>\r\n <%@ Import Namespace='Microsoft.SharePoint' %>\r\n <%@ Import Namespace='Microsoft.SharePoint.Utilities' %>\r\n <%@ Import Namespace='Microsoft.SharePoint.WebControls' %>\r\n <html>\r\n <head> <meta name='progid' content='SharePoint.Link' /> </head>\r\n <body>\r\n <form id='Form1' runat='server'>\r\n <SharePoint:UrlRedirector id='Redirector1' runat='server' />\r\n </form>\r\n </body>\r\n </html>";
          StringBuilder fileContent = new StringBuilder(fileTemplate.Length + 400);
          fileContent.AppendFormat(fileTemplate, typeof(SPDocumentLibrary).Assembly.FullName);
          Hashtable properties = new Hashtable();
          SPContentTypeId ctId = contentType.Id;
          properties["ContentTypeId"] = ctId.ToString();
          SPFile file = files.Add(fileUrl, new MemoryStream((new UTF8Encoding()).GetBytes(fileContent.ToString())), properties, false, false);
          SPListItem item = file.Item;
          item[FLD_URL] = urlVal;
          if (list.Fields.Contains(g_guidIconOverride)) item[g_guidIconOverride] = string.Concat("|", overrideIcon ?? extension, "|");
          item.IconOverlay = "linkoverlay.gif";
          item.UpdateOverwriteVersion();
          return item;
       }
    }
