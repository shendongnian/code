        public static void JsonParser(string file)
        {
            string fullname;
            string gender;
            string nationality;
            string maritalstatus;
            var json = System.IO.File.ReadAllText(file);
            var objects = JObject.Parse(json);
            fullname = (string)objects["DefaultPosition"]["NameComponents"]["FullName"];
            Console.WriteLine(fullname);
            Console.WriteLine("\n");
        }`
