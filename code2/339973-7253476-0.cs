    //Constructor
    public CubeRepository()
    {
        allCubes = new List<Cube>();
        CubeData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Cubes/Cubep10p11.xml"));
        var cubes = from cube in CubeData.Descendants("item")
                    select new Cube(cube.Element("ID").Value, 
                        cube.Element("Name").Value, 
                        cube.Element("Type").Value,
                        (int)cube.Element("Kr"),
                        (int)cube.Element("Euro"));
        allCubes.AddRange(cubes.ToList<Cube>());
    }
