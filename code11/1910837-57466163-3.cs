            public void Post()
            {
                string text = "";
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                    text = reader.ReadToEnd();
    
                dynamic dynObj = JObject.Parse(text);
    
                var firstValue = dynObj.Fields.first.Value;
                Console.WriteLine(firstValue);
            }
