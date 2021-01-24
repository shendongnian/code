            using (var r = new StreamReader(@"C:\Users\Admin\Desktop\Json.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<Dictionary<string, Item>>(json);
                foreach (var keyValuePair in items)
                {
                    Console.WriteLine(keyValuePair.Value.name);
                }
            }
