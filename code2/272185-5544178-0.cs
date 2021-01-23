    public virtual List<Foo> Foos {get;set;}
    public virtual string SerializedFoos 
    {
        get { return JsonConvert.Serialize(Foos); }
        set { Foos = JsonConvert.Deserialize<List<Foo>>(value); }
    }
