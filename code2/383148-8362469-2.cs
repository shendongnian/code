    void Main()
    {
        var members = FormatterServices.GetSerializableMembers(typeof(Foo));
        var propertyFieldAssoc = new PropertyFieldAssociation(typeof(Foo));
        foreach(var member in members)
        {
            var attributes = member.GetCustomAttributes(false).ToList();
            if (member is FieldInfo)
            {
                var property = propertyFieldAssoc.GetProperty((FieldInfo)member);
                if (property != null)
                {
                    attributes.AddRange(property.GetCustomAttributes(false));
                }
            }
            
            Console.WriteLine(member.Name);
            foreach(var attribute in attributes)
            {
                Console.WriteLine(" * {0}", attribute.GetType().FullName);
            }
            Console.WriteLine();
        }
    }
