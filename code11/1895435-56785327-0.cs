    using (var reader = new ResXResourceReader(AppDomain.CurrentDomain.BaseDirectory
                        + @"Properties\Resources.resx"))
                    {
                        Entries = reader.Cast<DictionaryEntry>().ToList();
                        var existingResource = Entries.Where(r => r.Key.ToString().ToLower()
                        == Key.ToLower()).FirstOrDefault();
                        if (existingResource.Key == null && existingResource.Value == null)
                        {
                            Entries.Add(new DictionaryEntry() { Key = Key, Value = Value });
                        }
                        else
                        {
                            var modifiedResx = new DictionaryEntry()
                            { Key = existingResource.Key, Value = Value };
                            Entries.Remove(existingResource);
                            Entries.Add(modifiedResx);
                        }
                    }
                    using (var writer = new ResXResourceWriter(AppDomain.CurrentDomain.BaseDirectory
                        + @"Properties\Resources.resx"))
                    {
                        Entries.ForEach(r =>
                        {
                            writer.AddResource(r.Key.ToString(), r.Value.ToString());
                        });
                        writer.Generate();
                    }
