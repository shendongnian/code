    private Version GetMsixPackageVersion()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var manifestPath = assembly.Location.Replace(assembly.ManifestModule.Name, "") + "\\AppxManifest.xml";
            if (File.Exists(manifestPath))
            {
                var xDoc = XDocument.Load(manifestPath);
                return new Version(xDoc.Descendants().First(e => e.Name.LocalName == "Identity").Attributes()
                    .First(a => a.Name.LocalName == "Version").Value);
            }
            return new Version(0,0,0,0);
        }
