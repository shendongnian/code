        public class Telegram
        {
            Response Response { get; set; }
            Notification Notification { get; set; }
            public static System.Reflection.PropertyInfo[] Properties(Telegram t)
            {
                System.Reflection.PropertyInfo[] properties = typeof(Telegram).GetProperties();
                return (System.Reflection.PropertyInfo[])properties.Select(x => x.GetValue(t,null)).Where(x => x != null).ToArray();
            }
        }
        public class Response
        {
        }
        public class Notification
        {
        }
