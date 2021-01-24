        public static void Main()
        {
            StreamReader objReader = new StreamReader(@"C:\\Temp\\data.txt");
            string orden = "";
            ArrayList arrText = new ArrayList();
            while (orden != null)
            {
                orden = objReader.ReadLine();
                if (orden != null)
                    arrText.Add(orden);
            }
            objReader.Close();
            foreach (string sOutput in arrText)
            { Console.WriteLine(sOutput); }
            Console.WriteLine("Order alphabetically descendant press 'a': ");
            Console.WriteLine("Ordener ascending alphabetical press 'b': ");
            orden = Console.ReadLine();
            switch (orden)
            {
                case "a":
                    arrText.Sort();
                    break;
                case "b":
                    arrText.Sort();
                    arrText.Reverse();
                    break;
            }
            foreach (string sTemp in arrText)
            { Console.Write(sTemp); }
            Console.WriteLine();
            Console.ReadLine();
        }
 
