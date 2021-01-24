    private const string str = @"
    <project>
       <nugets id='test'> </nugets>
       <packages>
          <package id='test1' version='1'/>
          <package id='Pkg1' version='1.2.3'/>
          <package id='Pkg1Test' version='4.5.6'/>
       </packages>
    </project>";
            private static void Test()
            {
                var el = XElement.Parse(str);
                var packages = el.Element("packages")?
                    .Elements("package")
                    .ToList();
                var package = packages?
                    .FirstOrDefault(x => x.Attribute("id")?.Value == "Pkg1");
                var id = package?.Attribute("version")?.Value;
                Console.Write(id);
            }
