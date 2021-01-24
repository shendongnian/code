    void Main()
    {
        var car = new Car();
        
        var imagens = typeof(Car).GetProperties()
            .Where(x => x.PropertyType == typeof(IFormFile))
            .Select(x => (IFormFile)x.GetValue(car))
            .Where(x => x != null)
            .ToList();
    }
