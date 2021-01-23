    // using a string key makes it easier to extend with new format.
    public interface IOutputRepository
    {
        //return null if the format was not found
        Output Get(string name);
    }
    
    // fetch a format using a static class with const strings.
    var output = repository.Get(OutputFormats.Pdf);
