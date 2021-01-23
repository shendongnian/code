    bool result = false;
            ArrayList emails = new ArrayList();
            emails.Add("test@test.org");
            emails.Add("Hello.com");
            emails.Add("hello@hotmail.com");
            foreach (string email in emails)
            {
                result = IsValidEmailID(email);
            }
