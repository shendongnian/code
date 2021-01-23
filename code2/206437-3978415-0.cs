            byte[] buffer = new byte[1024];
            using (Stream output = File.OpenWrite("filename"))
            {
                using (Stream resourceStream = typeof(Class1).Assembly.GetManifestResourceStream("name of resource"))
                {
                    int bytes = -1;
                    while ((bytes = resourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, bytes);
                    }
                }
            }
