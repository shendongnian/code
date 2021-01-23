        public static void AddUserToGroup(string userName)
        {
            // Read the users from the file
            List<string> users = File.ReadAllLines("group.txt").ToList();
            // Strip out the index number
            users = users.Select(u => u.Substring(u.IndexOf(". ") + 2)).ToList();
            users.Add(userName); // Add the new user
            users.Sort((x,y) => x.CompareTo(y)); // Sort
            // Reallocate the number
            for (int i = 0; i < users.Count; i++)
            {
                users[i] = (i + 1).ToString() + ". " + users[i];
            }
            // Write to the file again
            File.WriteAllLines("group.txt", users);
        }
