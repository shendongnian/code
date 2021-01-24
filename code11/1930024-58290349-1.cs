        set { _Data = JsonConvert.SerializeObject(value , Formatting.Indented, 
                new JsonSerializerSettings { 
                        ContractResolver = new CustomResolver(),
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        PreserveReferencesHandling = PreserveReferencesHandling.None
                });
        }
