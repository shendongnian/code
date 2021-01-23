    class Tag
    {
    	public int Id { get; set; }
        public string TagName { get; set; }
    	public int? ParentId { get; set; }    	
    	public IEnumerable<Tag> ChildNodes { get; set; }
    }
