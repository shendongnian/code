    var Lines = File.ReadAllLines(PathToYourFile);
            foreach (var line in Lines)
            {
                User user = new User();
                String[] AccDetails = line.Split(new[] { "|" }, StringSplitOptions.None);
                var username = AccDetails[0].Split(new[] { ":" }, StringSplitOptions.None);
                var password = AccDetails[1].Split(new[] { ":" }, StringSplitOptions.None);
                user.username = username[1];
                user.password = password[1];
            }
