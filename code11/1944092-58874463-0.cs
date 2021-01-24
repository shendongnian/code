            string[] UserActivity = File.ReadAllLines(@"path");
            string[] UserDateTime = File.ReadAllLines(@"path");
            DateTime greaterthanthis = new DateTime(2018, 2, 20);
            for (int i = 0; i < UserActivity.Length; i++)
            {
                if (DateTime.ParseExact(UserDateTime[i], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture) > greaterthanthis)
                {
                    Console.WriteLine(UserDateTime[i].ToString() + " : " + UserActivity[i]);
                }
             }
