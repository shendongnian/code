    private void setParam(string name) {
        FileName = name;
    }
    public MapReader(string fName) {
        setParam(fName);
    }
    public MapReader() {
        Console.WriteLine("Input valid file name:");
        string name = Console.ReadLine();
        setParam(name);
    }
