            public Task BindModelAsync(ModelBindingContext bindingContext)
            {
                var request = bindingContext.HttpContext.Request;
    
                using (var reader = new StreamReader(request.Body, Encoding.UTF8))
                {
                    var bodyString = reader.ReadToEnd();
                    var person = bodyString.DeSerialize<Person>(); //this is custom logic to de-serialize to object from JSON string
                    
                    //write your model binding logic here...
    
                    bindingContext.Result = ModelBindingResult.Success(person);
                }
    
                return Task.CompletedTask;
            }
