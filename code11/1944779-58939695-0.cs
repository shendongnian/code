			Kml kml = new Kml();
            kml.AddNamespacePrefix(KmlNamespaces.GX22Prefix, KmlNamespaces.GX22Namespace);
            
            var document = new Document();
            document.Name = "Doc";
            kml.Feature = document;
            var style_f = new Style();
            style_f.Id = "fol";
            var liststyle_f = new ListStyle();
            var itemicon_f = new ItemIcon();
			
            itemicon_f.State = ItemIconStates.Open | ItemIconStates.Closed;
            itemicon_f.Href = new Uri("green.png", UriKind.Relative);
            liststyle_f.AddItemIcon(itemicon_f);
            style_f.List = liststyle_f;
            document.AddStyle(style_f);
            var folder1 = new Folder();
            folder1.Name = "fol1";
            folder1.StyleUrl = new Uri("#fol", UriKind.Relative);
            document.AddFeature(folder1);
            
            var kml_file = @"C:\Users\user\Documents\kml_file.kml";
            KmlFile kmlfile = KmlFile.Create(kml, false);
            using (var stream = System.IO.File.OpenWrite(kml_file))
            {
                kmlfile.Save(stream);
            }
