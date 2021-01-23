    var files = Directory.GetFiles(yourSolutionDir, "*.csproj", SearchOption.AllDirectories);
    foreach (var f in files) {
      string contents = File.ReadAllText(f);
      string result = contents.Replace("<Compile Include=\"Properties\\AssemblyInfo.cs\" />", putSecondStringHere_ItIsJustTooLong); // :)
      File.WriteAllText(f, contents);
    }
