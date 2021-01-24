    Type type = Type.GetType("System.IO", "Direcory");
    MetadataReference[] references =
    {
        MetadataReference.CreateFromFile(path: 
         type.Assembly.Location)
     }
