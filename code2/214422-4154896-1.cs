            using (var resourceStream = Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream(resourceName))
            {
                if (resourceStream != null)
                {
                    using (var textStreamReader = new StreamReader(resourceStream))
                    {
                        text = textStreamReader.ReadToEnd();
                    }
                }
                else
                {
                    throw (new MissingManifestResourceException(resourceName));
                }
            }
