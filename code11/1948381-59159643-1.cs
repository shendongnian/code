    using System;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    // ...
    // get full resourceName from current assembly using Linq
    var messagesResourceFullName = Assembly.GetExecutingAssembly()
                                  .GetManifestResourceNames()
                                  .Where(n => n.EndsWith("Messages.xsd"));
    using (var schemaStream = asm.GetManifestResourceStream(messagesResourceFullName))
    {
        if (schemaStream == null) throw new FileNotFoundException();
        using (var schemaReader = XmlReader.Create(schemaStream))
        {
            settings.Schemas.Add(root.Namespace, schemaReader);
        }
    }
