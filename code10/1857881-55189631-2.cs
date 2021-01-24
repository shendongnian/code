    static List<user> ReadUsers()
        {
            List<user> tmp_users = new List<user>();
            var Lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "users.txt");
            foreach (var line in Lines)
            {
                user user = new user();
                String[] AccDetails = line.Split(new[] { "|" }, StringSplitOptions.None);
                var username = AccDetails[0].Split(new[] { ":" }, StringSplitOptions.None);
                var password = AccDetails[1].Split(new[] { ":" }, StringSplitOptions.None);
                user.Username = username[1];
                user.Password = password[1];
                tmp_users.Add(user);
            }
            return tmp_users;
        }
        static void WriteUsers()
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "users.txt", false))
            {
                foreach (user user in users)
                {
                    writer.WriteLine("Username:" + user.Username + "|Password:" + user.Password);
                }
            }
        }
