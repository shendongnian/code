    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Microsoft.Office.Interop.OneNote;
    
    namespace OneNote
    {
        class Program
        {
            static Application onenoteApp = new Application();
            static XNamespace ns = null;
    
            static void Main(string[] args)
            {
                GetNamespace();
                string notebookId = GetObjectId(null, HierarchyScope.hsNotebooks, "Tasks");
                string sectionId = GetObjectId(notebookId, HierarchyScope.hsSections, "Notes");
                string pageId = CreatePage(sectionId, "Test");          
            }
    
            static void GetNamespace()
            {
                string xml;
                onenoteApp.GetHierarchy(null, HierarchyScope.hsNotebooks, out xml);
    
                var doc = XDocument.Parse(xml);
                ns = doc.Root.Name.Namespace;
            }
    
            static string GetObjectId(string parentId, HierarchyScope scope, string objectName)
            {
                string xml;
                onenoteApp.GetHierarchy(parentId, scope, out xml);
    
                var doc = XDocument.Parse(xml);
                var nodeName = "";
    
                switch (scope)
                {
                    case (HierarchyScope.hsNotebooks): nodeName = "Notebook"; break;
                    case (HierarchyScope.hsPages): nodeName = "Page"; break;
                    case (HierarchyScope.hsSections): nodeName = "Section"; break;
                    default:
                        return null;
                }
    
                var node = doc.Descendants(ns + nodeName).Where(n => n.Attribute("name").Value == objectName).FirstOrDefault();
    
                return node.Attribute("ID").Value;
            }
    
            static string CreatePage(string sectionId, string pageName)
            {
                // Create the new page
                string pageId;
                onenoteApp.CreateNewPage(sectionId, out pageId, NewPageStyle.npsBlankPageWithTitle);
    
                // Get the title and set it to our page name
                string xml;
                onenoteApp.GetPageContent(pageId, out xml, PageInfo.piAll);
                var doc = XDocument.Parse(xml);
                var title = doc.Descendants(ns + "T").First();
                title.Value = pageName;
    
                // Update the page
                onenoteApp.UpdatePageContent(doc.ToString());
    
                return pageId;
            }
        }
    }
