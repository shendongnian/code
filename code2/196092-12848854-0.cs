                string fileName = @"C:\MyFolder\MyProjectFile.csproj";
    
                XDocument xDoc = XDocument.Load(fileName);
    
                XNamespace ns = XNamespace.Get("http://schemas.microsoft.com/developer/msbuild/2003");
    
                //References "By DLL (file)"
                var list1 = from list in xDoc.Descendants(ns + "ItemGroup")
                            from item in list.Elements(ns + "Reference")
                            /* where item.Element(ns + "HintPath") != null */
                            select new
                               {
                                   CsProjFileName = fInfo.Name,
                                   ReferenceInclude = item.Attribute("Include").Value.Replace(",", "__"),
                                   RefType = (item.Element(ns + "HintPath") == null) ? ReferenceType.CompiledDLLInGac : ReferenceType.CompiledDLL,
                                   HintPath = (item.Element(ns + "HintPath") == null) ? string.Empty : item.Element(ns + "HintPath").Value.Replace(",", "__")
                               };
    
    
                foreach (var v in list1)
                {
                    Console.WriteLine(v.ToString());
                }
    
    
                //References "By Project"
                var list2 = from list in xDoc.Descendants(ns + "ItemGroup")
                            from item in list.Elements(ns + "ProjectReference")
                            where
                            item.Element(ns + "Project") != null
                            select new
                            {
                                CsProjFileName = fileName,
                                ReferenceInclude = item.Attribute("Include").Value,
                                RefType = "ProjectReference",
                                ProjectGuid = item.Element(ns + "Project").Value
                            };
    
    
                foreach (var v in list2)
                {
                    Console.WriteLine(v.ToString());
                }
