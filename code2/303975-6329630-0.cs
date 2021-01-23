    string path = System.IO.Path.GetDirectoryName( 
          System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
    
    string filename="yourfilename";
    
    this.BackgroundImage = Image.FromFile(Path.Combine(path ,filename)); 
