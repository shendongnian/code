    /// <summary>
    /// Generic post request.
    /// </summary>
    /// <typeparam name="K">Request Type</typeparam>
    /// <typeparam name="T">Response Type</typeparam>
    /// <param name="query">e.g. user.validate</param>
    /// <param name="request">The Request</param>
    /// <returns></returns>
    public T PostRequest<K, T>(string query, K request)
    {
        using (var client = GetDefaultClient())
        {
            // build form data post
            HttpMultipartMimeForm form = CreateMimeForm<K>(request);
    
            // call method
            using (HttpResponseMessage response = client.Post(query, form.CreateHttpContent()))
            {
                response.EnsureStatusIsSuccessful();
                return response.Content.ReadAsXmlSerializable<T>();
            }
        }
    }
    
    /// <summary>
    /// Builds a HttpMultipartMimeForm from a request object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request"></param>
    /// <returns></returns>
    public HttpMultipartMimeForm CreateMimeForm<T>(T request)
    {
        HttpMultipartMimeForm form = new HttpMultipartMimeForm();
    
        Type type = request.GetType();
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            foreach (Attribute attribute in property.GetCustomAttributes(true))
            {
                RequiredAttribute requiredAttribute = attribute as RequiredAttribute;
                if (requiredAttribute != null)
                {
                    if (!requiredAttribute.IsValid(property.GetValue(request, null)))
                    {
                        //Console.WriteLine("{0} [type = {1}] [value = {2}]", property.Name, property.PropertyType, property.GetValue(property, null));
                        throw new ValidationException(String.Format("{0} [type = {1}] requires a valid value", property.Name, property.PropertyType));
                    }
                }
            }
    
            if (property.PropertyType == typeof(FileInfo))
            {
                FileInfo fi = (FileInfo)property.GetValue(request, null);
                HttpFormFile file = new HttpFormFile();
                file.Content = HttpContent.Create(fi, "application/octet-stream");
                file.FileName = fi.Name;
                file.Name = "image";
    
                form.Files.Add(file);
            }
            else
            {
                form.Add(property.Name, String.Format("{0}", property.GetValue(request, null)));
            }
        }
    
        return form;
    }
