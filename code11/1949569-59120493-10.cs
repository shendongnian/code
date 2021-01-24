    namespace Business
    {
        public class DateTime
        {
            public static System.DateTime Now => System.DateTime.UtcNow.AddHours(1);
        }
    }
