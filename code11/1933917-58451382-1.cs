    using (StreamReader reader = new StreamReader(file))
    {
        while ((line = reader.ReadLine()) != null) // HERE
        {
            line = reader.ReadLine(); // AND HERE
            string name = "";
            List<int> parents = new List<int>();
            List<float> probs = new List<float>();
            string[] splitLine = line.Split('/');
            Console.WriteLine("splitLine array: ");
            foreach (string item in splitLine)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            int index = 2;
            name = splitLine[0];
            if (splitLine.Length == 4)
            {
                string[] temp = splitLine[2].Split(' ');
                foreach (string item in temp)
                parents.Add(Int32.Parse(item));
                index = 3;
            }
            string[] temp1 = splitLine[index].Split(' ');
            foreach (string item in temp1)
                probs.Add(float.Parse(item, CultureInfo.InvariantCulture.NumberFormat));
                Node newNode = new Node(name, parents, probs);
                graph.Add(newNode);
        }
    }
