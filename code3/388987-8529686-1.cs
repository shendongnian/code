            // Assume there is only a single line in the file
            string sLineToProcess = System.IO.File.ReadAllText("usin.txt");
            var oData = new EFTData();
            // Parse the us data
            oData.FromUSFormat(sLineToProcess);
            // Write the canadian data
            using (var oWriter = new StreamWriter("canout.txt"))
            {
                oWriter.Write(oData.ToCanadianFormat());
            }
