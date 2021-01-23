        var input = "This is some amazing Rexex Stuff!";
                input = Regex.Replace(input, @"[\W]+", "-").ToLower();
                input = Regex.Replace(input, @"[-]+$", "");
                Console.Write(input);
                Console.Read();
