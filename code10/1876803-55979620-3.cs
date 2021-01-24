     UserDetails SearchFor(String searchName)
            {
                var strLines = File.ReadLines(filePath);
                foreach (var line in strLines)
                {
                    var bits = line.Split(',');
                    if (bits[0].Equals(searchName))
                    {
                        return new UserDetails()
                        {           
                            surname = bits[1],
                            city = bits[2],
                            state = bits[3],                     
                        };
                    }
                }
                return new UserDetails()
                        {           
                            surname = "Default text",
                            city = "Default text",
                            state = "Default text",                     
                        }; //Here you need to fix
            }
