    public object DoWork(string entityPath, Type type) {
        // get 'json' using 'entityPath'
        var listType = typeof(List<>).MakeGenericType(type);
        return JsonConvert.DeserializeObject(json, listType);
    }
