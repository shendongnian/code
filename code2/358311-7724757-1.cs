        private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            if(args.Name == "Proband, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
            {
                // resolving correct assembly of type under test
                return typeof(ExampleMethods).Assembly;
            }
            else
            {
                return null;
            }
        }
