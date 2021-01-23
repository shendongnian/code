    class Program
        {
            struct AuthSession
            {
                public string username;
                public string accessLevel;
            }
            class AuthSession2
            {
                public string Username { get; set; }
                public string AccessLevel { get; set; }
            }
            static void Main(string[] args)
            {
                AuthSession session = new AuthSession();
                AuthSession2 session2 = new AuthSession2();
                DoStuff(session);
                DoStuff(session2);
                Console.WriteLine(session.username + " " + session.accessLevel);
                Console.WriteLine(session2.Username + " " + session2.AccessLevel);
            }
            static void DoStuff(AuthSession session)
            {
                session.username = "a";
                session.accessLevel = "a";
            }
            static void DoStuff(AuthSession2 session)
            {
                session.Username = "a";
                session.AccessLevel = "a";
            }
        }
