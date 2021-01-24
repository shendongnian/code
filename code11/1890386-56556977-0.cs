    private static Rootobject publicFeed;
        public static void Set()
        {
            publicFeed = new Rootobject();
            using (var client = new WebClient())
            {
                string result;
                try
                {
                    result = client.DownloadString("your json");//configure json stringdata
                }
                catch (Exception)
                {
                    Console.WriteLine("This application needs a valid internet connection, please try again.");
                    result = null;
                    return;
                }
                publicFeed = JsonConvert.DeserializeObject<Rootobject>(result);
            }
        }
