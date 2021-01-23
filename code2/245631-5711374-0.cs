            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket( 
                                                  1,                                        // Ticket version
                                                   username,                                 // Username associated with ticket
                                                   DateTime.Now,                             // Date/time issued
                                                   DateTime.Now.AddDays(1),                 // Date/time to expire
                                                   isPersistent,                             // "true" for a persistent user cookie
                                                   dataStore,                                // User-data, in this case the roles
                                                   FormsAuthentication.FormsCookiePath);     // Path cookie valid for
            // Encrypt the cookie using the machine key for secure transport
            string Hash = FormsAuthentication.Encrypt(Ticket);
            HttpCookie Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Hash);
            // Set the cookie's expiration time to the tickets expiration time
            if (Ticket.IsPersistent)
                Cookie.Expires = Ticket.Expiration;
