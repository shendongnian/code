    using (MemoryStream ms = new MemoryStream(packageParts)) {
        using (Package package = Package.Open(ms, FileMode.Open, FileAccess.ReadWrite)) {
            PackagePart section = package.GetParts().Where(x => x.Uri.OriginalString == "/Formulas/Section1.m").FirstOrDefault();
            string query;
            using (StreamReader reader = new StreamReader(section.GetStream())) {
                query = reader.ReadToEnd();
                // do other replacing, removing of query here
            }
            using (BinaryWriter writer = new BinaryWriter(section.GetStream())) {
                // write updated query back to package part
                writer.Write(Encoding.ASCII.GetBytes(query));
            }
        }
        packageParts = ms.ToArray();
    }
