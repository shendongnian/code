    public static bool CheckEmail(string email)
        {
            //validate Email
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.\']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$", RegexOptions.IgnoreCase);
            Match match = regex.Match(email);
            return match.Success;
        }
