    Type yourType = typeof(List<string>);  // for example
    using (var provider = new CSharpCodeProvider())
      {
           var typeRef = new CodeTypeReference(f.FieldType);
           string[] name = provider.GetTypeOutput(typeRef).Split('.');
           s.Append(" : ").Append(name[name.Length-1]);
      }
