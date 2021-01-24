      string Foo(Resource parameter = null)
        {
            Resource r;
            if (parameter == null)
            {
                parameter  = new Resource();
            }
            using (r = parameter)
            {
                // whatever you want to do.
                return;
            }
            
        }
