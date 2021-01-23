        //outputfilename will be something like: "C:/MyFolder/MyFile.txt"
        void WriteDictionaryAsJson(Dictionary<string, List<string>> myDict, string outputfilename)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Dictionary<string, List<string>>));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, myDict); //Does the serialization.
            StreamWriter streamwriter = new StreamWriter(outputfilename);
            streamwriter.AutoFlush = true; // Without this, I've run into issues with the stream being "full"...this solves that problem.
            ms.Position = 0; //ms contains our data in json format, so let's start from the beginning
            StreamReader sr = new StreamReader(ms); //Read all of our memory
            streamwriter.WriteLine(sr.ReadToEnd()); // and write it out.
            ms.Close(); //Shutdown everything since we're done.
            streamwriter.Close();
            sr.Close();
        }
