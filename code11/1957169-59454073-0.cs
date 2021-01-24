       public void Add(string vertex)
    {
        this.vertices.Add(vertex);
        List<int> temp = new List<int>();
        foreach(List<int> element in this.adjacencyMatrix)
        {
            element.Add(0);
        }
        foreach(string element in vertices)
        {
            temp.Add(0);
        }
        this.adjacencyMatrix.Add(temp);
        
        this.n++;
    }
      public void AddConnection(string vertex1, string vertex2, int value)
    {
       if(this.vertices.Contains(vertex1) && this.vertices.Contains(vertex2))
        {
           int index1= this.vertices.IndexOf(vertex1);
            int index2 = this.vertices.IndexOf(vertex2);
            this.adjacencyMatrix[index1][index2] = value;
            this.adjacencyMatrix[index2][index1] = value;
        }
        else
        {
            Console.WriteLine("Graph doesn't contain passed vertex/vertices.");
        }
    }
    public void SaveMatrix(string filename)
    {
        // save matrix with nice formatting
        // works if the names of the vertices are shorter than 16 chars and if edge weights are shorter than 100 (and positive)
        try
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.Write("".PadRight(16)); // pad a string with white spaces to get exactly the specified length in chars
            foreach (string s in vertices) sw.Write(s.PadRight(16)); // write first row with names
            sw.WriteLine();
            int counter = 0;
            foreach (List<int> column in adjacencyMatrix) // other rows
            {
                sw.Write(vertices[counter].PadRight(16)); // start with vertex name
                counter++;
                foreach (int i in column)
                {
                    if (i >= 10) sw.Write(i + "".PadRight(15)); // two digits
                    else if (i > 0) sw.Write("0" + i + "".PadRight(15)); // one digit
                    else sw.Write("--" + "".PadRight(15)); // no connection
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine("Error - the file could not be read");
            Console.WriteLine(e.Message);
        }
    }
