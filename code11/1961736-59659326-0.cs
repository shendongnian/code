    List<Type> subclassTypes = Assembly
            .GetAssembly(typeof(ParentClass))
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(ParentClass))).ToList();
    comboBoxTypes.DataSource = subclassTypes;
    comboBoxTypes.DisplayMember = "Name";
