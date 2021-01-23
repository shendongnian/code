    foreach(var command in commands)
    {
        var splits = command.Split('#');
        if(!String.IsNullOrEmpty(splits[0]))
        {
            _handle.WriteString(splits[0]);
        }
    }
