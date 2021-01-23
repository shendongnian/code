            try
            {
                var header = HttpContext.Current.Response;
                header.AppendHeader("test0", "1");
                header.AppendHeader("test1", "2");
                header.AppendHeader("test2", "2");
                header.AppendHeader("test3", "3");
                header.AppendHeader("test4", "4");
                MethodInfo dynMethod = header.GetType().GetMethod("GenerateResponseHeaders", BindingFlags.NonPublic | BindingFlags.Instance);
                var result =  dynMethod.Invoke(header, new object[] { false });
            }
            catch (HttpRequestValidationException ex)
            {
                string str = ex.Message;
            }
