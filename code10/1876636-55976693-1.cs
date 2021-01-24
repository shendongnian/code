    async void AsyncToConsole(Uri uri, Action<Animal> action) {
    
        using (var client = new HttpClient())
        {
            var getReg = await client.GetAsync(uri);
            var json = await getReg.Content.ReadAsStringAsync();                
            Animal animal;
            try
            {
                animal = (SimpleJson.DeserializeObject<Animal>(json));
                action(animal);
            }
            catch (Exception)
            {
                action(new Animal() { kingdom = "error", confidence = 0, phylum = "error" });
            }
        }
    }
