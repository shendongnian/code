    public Text[] elements;
    public string[] variables;
    void Start()
    {
        Random rndom = new Random();
        List<int> possible = Enumerable.Range(0, variables.Length).ToList();
    
        for (int i = 0; i < elements.Length; i++)
        {  
            int index = rndom.Next(0, possible.Count);
            elements[i].text = variables[possible[index]];
            Console.WriteLine(possible[index]);
            possible.RemoveAt(index);               
         }
    }
