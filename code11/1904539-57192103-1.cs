    var possibles = values.ToLookup(v => v.Substring(0, 2));
    using (FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
        using (StreamReader sr = new StreamReader(fs)) {
            using (var writer = File.CreateText(tempFile)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    var index = line.Substring(0, 2);
                    foreach (var value in possibles[index]) {
                        if (line.StartsWith(value)) {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
