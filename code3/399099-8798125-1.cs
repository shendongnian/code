    var assembly = Assembly.GetExecutingAssembly();
    // See what resources are in the assembly (remove from the final code)
    foreach (var name in assembly.GetManifestResourceNames()) {
        Console.Writeline("'{0}'", name);
    }
    using (var inputStream = assembly.GetManifestResourceStream(resourcePath)) {
        using( var outStream = File.OpenWrite(copyToPath)) {
            input.CopyTo(outStream);
        }
    }
 
