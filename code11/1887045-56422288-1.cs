    var enumDictionary = Enum.GetValues(typeof(T))
        .Cast<T>()
        .Select(x => new
        {
            name = x.GetType().GetMember(x.ToString()).FirstOrDefault().GetCustomAttribute<DisplayAttribute>().GetName(),
            value = Convert.ToInt32(Enum.Parse(typeof(T), x.ToString()))
        })
        .ToList();
