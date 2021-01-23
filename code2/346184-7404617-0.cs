    using (var ms = new MemoryStream())
    {
        // Create the serializer.
        var dcs = new DataContractSerializer(typeof(ProjectSetup));
        // Serialize to the stream.
        dcs.WriteObject(ms, System.Web.HttpContext.Current.Session["ProjectSetup"]);
