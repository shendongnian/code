        // This will list ALL the properties from AD (between 200 and 800..or more)
        // If someone has a solution for non AD servers please post it!
        List<String> properties = new List<String>();
        IPAddress[] ips = Dns.GetHostAddresses(Server).Where(w => w.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToArray();
        if (ips.Length > 0)
        {
            DirectoryContext directoryContext = new DirectoryContext(DirectoryContextType.DirectoryServer, ips[0].ToString() + ":389", Username, Password);
            ActiveDirectorySchema adschema = ActiveDirectorySchema.GetSchema(directoryContext);
            ActiveDirectorySchemaClass adschemaclass = adschema.FindClass("User");
            // Read the OptionalProperties & MandatoryProperties
            ReadOnlyActiveDirectorySchemaPropertyCollection propcol = adschemaclass.GetAllProperties();
            foreach (ActiveDirectorySchemaProperty schemaProperty in propcol)
                properties.Add(schemaProperty.Name.ToLower());
        }
