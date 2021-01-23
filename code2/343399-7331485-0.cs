    public class OutputFormats1 : OutputFormatsBase<OutputFormats1> 
    { 
        public static readonly OutputFormats1 Bmp = new OutputFormats1 { Value = "BMP", FileExtension = "bmp", Id = 1 }; 
        public static readonly OutputFormats1 Jpg = new OutputFormats1 { Value = "JPG", FileExtension = "jpg", Id = 2 }; 
        public static readonly OutputFormats1 Png = new OutputFormats1 { Value = "PNG", FileExtension = "png", Id = 3 }; 
        public static readonly OutputFormats1 Tiff = new OutputFormats1 { Value = "TIFF", FileExtension = "tif", Id = 4 }; 
        public override OutputFormatsBase Selected { get; set; } 
        public override OutputFormatsBase Default 
        { 
            get { return Png; } 
        } 
    } 
     
    public class OutputFormats2 : OutputFormatsBase<OutputFormats2> 
    { 
        public static readonly OutputFormats2 Pdf = new OutputFormats2 { Value = "PDF", FileExtension = "pdf", Id = 1 }; 
        public override OutputFormatsBase Selected { get; set; } 
        public override OutputFormatsBase Default 
        { 
            get { return Pdf; } 
        } 
    } 
     
    public abstract class OutputFormatsBase<T> where T:OutputFormatsBase 
    { 
         private static readonly List<T> _listOfObjects = new List<T>(); 
         public string Value { get; protected internal set; } 
         public string FileExtension { get; protected internal set; } 
         public int Id { get; protected internal set; } 
     
         public abstract OutputFormatsBase Selected { get; set; } 
         public abstract OutputFormatsBase Default { get; } 
     
     
         protected OutputFormatsBase() 
         { 
             _listOfObjects.Add((T)this); 
         } 
     
     
         public bool Validate(string format) 
         { 
             for (var i = 0; i < _listOfObjects.Count - 1; i++) 
             { 
                 var outputFormats = _listOfObjects[i]; 
                 if (format.ToLower() == outputFormats.Value.ToLower()) 
                 { 
                     Selected = outputFormats; 
                     return true; 
                 } 
             } 
             return false; 
         } 
     } 
