    string[] asmInfo = File.ReadAllLines(file);
    var transformedLines = asmInfo.Select(
        x => x.Trim().StartsWith("[assembly: AssemblyVersion")
            ? "[assembly: AssemblyVersion\"" + version + "\")]"
            : x
        );
    File.WriteAllLines(file, asmInfo.ToArray());
