    public IEnumerable<Foo> Search(string param)
    {
        if (string.IsNullOrEmpty(param))
        {
            return this.fooRepository.GetAll().ToArray();
        }
        return this.fooRepository.GetAllByFilter(o => o.Field.Contains(param.Trim())).ToArray();
    }
