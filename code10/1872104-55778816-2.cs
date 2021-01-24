            //string TextResult = "";
            ClientDocList documentRepository = GetClientDocList();
            var directoryPath = "";
            var clientID = 1;
            var clientDocList = documentRepository.Documents.Where(c => c.ClientID == clientID).ToList();
            if (Directory.Exists(directoryPath) || true) // I need to pass your condition
            {
                string[] files = new string[] { "file1", "file5", "file6" };  
                List<string> fileList = files.Select(x => x.Trim().ToUpper()).ToList(); // I like working with lists, if you want an array it's ok
                foreach (var clientDoc in clientDocList.Where(c => !fileList.Contains(c.DocFileName.Trim().ToUpper())))
                {
                    //TextResult += $" {clientDoc.DocFileName} does not exists so you have to delete it from db";
                    documentRepository.Delete(clientDoc);
                }
            }
            //Console.WriteLine(TextResult);
