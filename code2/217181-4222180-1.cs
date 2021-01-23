    public void Activate(int Id, Action<T> doSomething)
    {
        T Entity = this._repository.Select(Id);
        // Need to get the property here, change it and move on... 
        doSomething(Entity);
        _repository.Submit();
    }
