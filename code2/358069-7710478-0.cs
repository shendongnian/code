    using System.Linq;
    private readonly string[] _matches = new[] { ".jpg", ".bmp", ".png", ".gif", ".bmp" };    
    
    // Assumes extension is in the format ".jpg", "bmp", so trim the
    // whitespace from start and end
    public bool IsMatch(string extension)
    {
         return _matches.Contains(extension);
    }
