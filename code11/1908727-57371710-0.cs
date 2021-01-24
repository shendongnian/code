    public class EmailNotification
            {
                public IDateTimeWrapper DateTimeWrapper { get; set; }
                public void SetBody(string body)
                {
                    ...
                    Body = body + DateTimeWrapper.Now.ToString();
                }
            }
