    public void EditCube(Cube cube)
    {
        XElement node = CubeData.Root.Elements("item").Where(i => (string)i.Element("ID") == cube.ID).FirstOrDefault();
        node.SetElementValue("ID", cube.ID);
        node.SetElementValue("Name", cube.Name);
        node.SetElementValue("Type", cube.Name);
        node.SetElementValue("Kr", cube.Kr);
        node.SetElementValue("Euro", cube.Euro);
        CubeData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Cubes/Cubep10p11.xml"));
    }
