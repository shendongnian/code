     using Newtonsoft.Json;
         [TestMethod]
            public void ExportJson()
            {
            double[,] b = new double[,] {
                { 110, 120, 130, 140, 150 },
                { 1110, 1120, 1130, 1140, 1150 },
                { 1000, 1, 5 ,9, 1000},
                {1110, 2, 6 ,10,1110},
                {1220, 3, 7 ,11,1220},
                {1330, 4, 8 ,12,1330} };
            string jsonStr = JsonConvert.SerializeObject(b);
            Console.WriteLine(jsonStr);
            string path = "X:\\Programming\\workspaceEclipse\\PyTutorials\\src\\tensorflow_tutorials\\export.txt";
            File.WriteAllText(path, jsonStr);
        }
