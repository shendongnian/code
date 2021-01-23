    public IEnumerable<Foo> Search(string param)
    {
        if (string.IsNullOrEmpty(param))
        {
            return this.fooRepository.GetAllByFilter(o => true).ToArray(); // or GetAll()??
        }
        return this.fooRepository.GetAllByFilter(o => o.Field.Contains(param.Trim())).ToArray();
    }
