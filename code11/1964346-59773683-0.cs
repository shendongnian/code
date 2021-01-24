    public List<string> variables = new List<string>();
    public Text[] elements;
    void Start()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            string s = variables[Random.Range(0, variables.Count - 1)];
            elements[i].text = s;
            variables.Remove(s);
        }
    }
 
