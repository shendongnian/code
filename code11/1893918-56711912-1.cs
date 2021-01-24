	public int Person_Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Sample> Samples { get; set; }
	}
