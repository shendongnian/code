    public List<NewspaperDTO> GetNews()
    {
        using (var entities = new MyEntities())
        {
            return entities.Newspapers.Select(a => new NewspaperDTO(a)).ToList();
        }
    }
