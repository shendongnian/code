    public void enviarCorreo(String correo)
    {        
      ....
    var assembly = Assembly.GetExecutingAssembly();
    string[] names = assembly.GetManifestResourceNames();
    using( StreamReader reader = new StreamReader("proyectoHADS.LIbreriaClase.EmailTemplate.html" ) )
    {
     String line = String.Emtpy;
     while( (line = reader.ReadLine()) != null )
     {
      Console.WriteLine(line);
     }
    }
