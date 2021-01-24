    var candidates = new []
            {
                new {
                    name = "candidate a",
                    data = new
                        {
                            tag = "id",
                            pattern = "(.+)"
                        }
                },
                new
                {
                    name =  "candidate b",
                    data = new
                    {
                        tag = "whatever",
                        pattern = "whatever"
                    }
                }
            };
            var result = candidates.Single(o => o.name == "candidate a");
