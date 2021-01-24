            var list = new List<Animal>();
            var r = JsonConvert.DeserializeObject<Dictionary<string, string>>(data).Values.ToArray();
            for (int i = 0; i < r.Length; i+=2)
            {
                list.Add(new Animal()
                {
                    Name = r[i],
                    Map = r[i+1]
                });
            }
