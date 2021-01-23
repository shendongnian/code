    private Dictionary<string, Type> typeLookup;
    public ITask GetInstance(string typeName)
    {
        if (typeLookup == null)
        {
            typeLookup = new Dictionary<string, Type>();
            var tasks = ObjectFactory.GetAllInstances<ITask>();
            foreach (var task in tasks)
            {
                typeLookup.Add(task.GetType().Name, task.GetType());
            }
        }
        return (ITask)ObjectFactory.GetInstance(typeLookup[typeName]);
    }
