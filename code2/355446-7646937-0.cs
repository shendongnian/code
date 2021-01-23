    Service service = new ContactsService("My Contacts Application");
            service.setUserCredentials("mail@gmail.com", "password");
            var token = service.QueryClientLoginToken();
            service.SetAuthenticationToken(token);
            var query = new ContactsQuery(@"https://www.google.com/m8/feeds/contacts/mail@gmail.com/full?max-results=25000");
            var feed = (ContactsFeed)service.Query(query);
            Console.WriteLine(feed.Entries.Count);
            foreach (ContactEntry entry in feed.Entries)
            {
                Console.WriteLine(entry.Title.Text);
            }
