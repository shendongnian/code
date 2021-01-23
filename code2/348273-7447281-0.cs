        public const string Index = "messages-some-unique-key";
        public static void AddMessage(this HttpSessionStateBase session, string message, string messageClass)
        {
            if (session[Index] == null)
                session[Index] = new List<KeyValuePair<string, string>>();
            var list = (IList<KeyValuePair<string, string>>) session[Index];
            list.Add(new KeyValuePair<string, string>(
                         message, messageClass));
        }
