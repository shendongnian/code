    var assembly = Assembly.GetExecutingAssembly();
    using (var inputStream = assembly.GetManifestResourceStream(resourcePath)) {
        using( var outStream = File.OpenWrite(copyToPath)) {
            input.CopyTo(outStream);
        }
    }
 
