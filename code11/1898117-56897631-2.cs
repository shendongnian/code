        public static void Register(HttpConfiguration config)
        {
            // ...
            // add multipart/form-data formatter
            config.Formatters.Add(new FormMultipartEncodedMediaTypeFormatter());
            // ...
        }
