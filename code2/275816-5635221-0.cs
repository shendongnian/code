        // call this line only once in application lifetime (when app starts)
        ApplyFixEndDotUrl();
        // --------------------------
        // and then accros application you can use:
        Uri testUrl = new Uri("http://www.mattmulholland.co.nz/Matt_Mulholland/Matt_Mulholland_-_Official_Website._Boom./rss.xml");
        string strUrl = testUrl.ToString();
        // --------------------------
        // -> using System.Reflection;
        public static void ApplyFixEndDotUrl()
        {
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
                        if ((flagsValue & 0x1000000) != 0)
                            flagsField.SetValue(parser, flagsValue & ~0x1000000);
                    }
                }
            }
        }
