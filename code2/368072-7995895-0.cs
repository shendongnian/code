    var validate = new Dictionary<string, List<dynamic>> {
        {
            "(\\.org|\\.info|\\.biz|\\.name)$",
            new List<dynamic>
            {
                new {
                    Type = "size",
                    Pattern = @"^.{3,64}$",
                    Message = "Your domain can have at max 26 characters and at least 3."
                }
            }
        },
        {
            ".*",
            new List<dynamic>
            {
                new {
                    Type = "general",
                    Pattern = @"^[^\.-].*[^\.-]$",
                    Message = "Your domain name shouldn\'t contain . or - at the beginning or the end."
                },
                new {
                    Type = "characters",
                    Pattern = @"^[abcdefghijklmnopqrstwuvxyz0123456789]+$",
                    Message = "Your domain name should contain only alphanumeric characters."
                }
            }
        }
    };
