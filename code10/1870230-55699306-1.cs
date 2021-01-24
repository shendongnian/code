    class ProjectWithOnlyNameForCreateDto
    {
        public string name{get;set;}
    }
    [HttpPost]
    public void CreateMethod([FromBody] ProjectWithOnlyNameForCreateDto dto)
    {
        ....
    }
