    class ProjectWithOnlyNameForUpdateDto
    {
        public string name{get;set;}
    }
    [HttpPut]
    public void CreateMethod([FromBody] ProjectWithOnlyNameForUpdateDto dto)
    {
        ....
    }
