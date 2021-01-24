    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string NEW_FILENAME = @"c:\temp\test.xml";
            const string OLD_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XDocument newDoc = XDocument.Load(NEW_FILENAME);
                XDocument oldDoc = XDocument.Load(OLD_FILENAME);
                var query = (from oD in oldDoc.Descendants("file-manager").Elements()
                             join nD in newDoc.Descendants("file-manager").Elements() on oD.Name.LocalName equals nD.Name.LocalName
                             select new { name =  oD.Name.LocalName, oldDoc = oD, newDoc = nD })
                             .ToList();
                foreach (var part in query)
                {
                    //left outer join
                    var q = (from oldPart in part.oldDoc.Descendants("mount-point")
                             join newPart in part.newDoc.Descendants("mount-point") on (string)oldPart.Attribute("alias") equals (string)newPart.Attribute("alias") into ps
                             from newPart in ps.DefaultIfEmpty()
                             select new { newPart = newPart, oldPart = oldPart })
                            .ToList();
                    XElement newMountPoint = part.newDoc.Descendants("mount-points").FirstOrDefault(); 
                    foreach (var point in q)
                    {
                        if (point.newPart == null)
                        {
                            newMountPoint.Add(point.oldPart);
                        }
                    }
                }
            }
        }
    }
