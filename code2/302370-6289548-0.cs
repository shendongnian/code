            List<string> elements = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                elements.Add(i.ToString());
            }
            string src = "4";
            string target = "7";
            elements.Remove(src);
            int index = elements.IndexOf(target);
            elements.Insert(index, src);
            foreach (string e in elements)
            {
                Console.Write("{0} ", e);
            }
