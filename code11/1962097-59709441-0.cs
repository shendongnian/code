      [HttpPut]
            public HttpResponseMessage UpdateBox(HttpRequestMessage requestMsg, int boxId, JObject boxObj) // Step 1 : Change the input type C# Object to JObject
            {
                //Step 2: Get the Box entity instance by calling Get method. Save to Dto 
                BoxDto boxDto = _boxCommonService.GetBox(boxId);
                try
                {
                    // Step 3: Iterate the JObject and find is there any user set, Null values.
                    foreach (var prop in boxObj)
                    {
                        string key = prop.Key;
                        JToken value = prop.Value;
                        PropertyInfo propertyInfo = boxDto.GetType().GetProperty(key);
                        if (boxDto.GetType().GetProperty(key) == null)
                        {
                            return requestMsg.CreateResponse(HttpStatusCode.BadRequest, "invalid property name");
                        }
                        else
                        {
                            // Step 4: If there is any, update the Dto
                            boxDto.GetType().GetProperty(key).SetValue(boxDto, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                        }
                    }
                    // Step 5: Now you can call the service with auttomapper to map the entity with Dto. (Remove any autoMapper rule to ignore null values)           
                    _boxCommonService.UpdateBox(boxId, boxDto);
    );
