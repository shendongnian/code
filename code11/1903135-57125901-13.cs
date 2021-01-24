         HttpResponseMessage response = client.GetAsync("api/Student");
         var readAsStringAsync = response.Content.ReadAsStringAsync();
         string result = readAsStringAsync.Result;
         XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfStudent));
         using (TextReader reader = new StringReader(result))
         {
         ArrayOfStudent result = (ArrayOfStudent) serializer.Deserialize(reader);
         }
