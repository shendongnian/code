    Type type = Type.GetType("System.IO.Directory, System.IO.FileSystem");
    MetadataReference[] references =
    {
        MetadataReference.CreateFromFile(path: 
         type.Assembly.Location)
     }
