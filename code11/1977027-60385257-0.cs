    class Program
    {
       static void Main(string[] args)
       {
          DirectoryCatalog catalog = new DirectoryCatalog("plugins", "*.dll");
          CompositionContainer container = new CompositionContainer(catalog);
          container.ExportsChanged += Container_ExportsChanged;
          Console.WriteLine("Copy new plugins and press any key to refresh them.");
          Console.ReadKey();
          catalog.Refresh();
          Console.ReadLine();
       }
    
       private static void Container_ExportsChanged(object sender, ExportsChangeEventArgs e)
       {
          Console.Write("Added Exports: ");
          Console.WriteLine(string.Join(", ", e.AddedExports));
       }
    }
