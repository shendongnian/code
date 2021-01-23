    MethodInfo getSyntax = typeof(UriParser).GetMethod("GetSyntax", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
    FieldInfo flagsField = typeof(UriParser).GetField("m_Flags", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    if (getSyntax != null && flagsField != null)
    {
          foreach (string scheme in new[] { "http", "https" })
          {
              UriParser parser = (UriParser)getSyntax.Invoke(null, new object[] { scheme });
              if (parser != null)
              {
                  int flagsValue = (int)flagsField.GetValue(parser);
                  // Clear the CanonicalizeAsFilePath attribute
                  if ((flagsValue & 0x1000000) != 0)
                     flagsField.SetValue(parser, flagsValue & ~0x1000000);
               }
           }
    }
    
    Uri test = new Uri("http://server/folder.../");
    Console.WriteLine(test.PathAndQuery);
