          do
                {
                    foreach (User user in users)
                    {
                   if (user.Mail != null)
                   {
                        if (user.Mail.Contains("Tom"))
                        {
                           Console.WriteLine("Hurray");
                        }
                    }
                        Console.WriteLine($"{user.Id}");
                        Flag++;
                    }
                }
                while (users.NextPageRequest != null && (users = await users.NextPageRequest.GetAsync()).Count > 0);
