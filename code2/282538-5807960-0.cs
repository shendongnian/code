        static void Main()
        {
            string input = @"Thread-Topic: test subject
    Thread-Index: AcwE4mK6Jj19Hgi0SV6yYKvj2/HJbw==
    From: ""Lastname, Firstname"" <firstname_lastname@domain.com>
    To: <testto@domain.com>, ""Yes, this is valid""@[emails are hard to parse!], testto1@domain.com, testto2@domain.com
    Cc: <testcc@domain.com>, test3@domain.com
    X-OriginalArrivalTime: 27 Apr 2011 13:52:46.0235 (UTC) FILETIME=[635226B0:01CC04E2]";
            Regex toline = new Regex(@"(?im-:^To\s*:\s*(?<to>.*)$)");
            string to = toline.Match(input).Groups["to"].Value;
            int from = 0;
            int pos = 0;
            int found;
            string test;
            
            while(from < to.Length)
            {
                found = (found = to.IndexOf(',', from)) > 0 ? found : to.Length;
                from = found + 1;
                test = to.Substring(pos, found - pos);
                try
                {
                    System.Net.Mail.MailAddress addy = new System.Net.Mail.MailAddress(test.Trim());
                    Console.WriteLine(addy.Address);
                    pos = found + 1;
                }
                catch (FormatException)
                {
                }
            }
        }
