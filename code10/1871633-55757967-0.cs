    class Program
    {
        static void Main(string[] args)
        {
            try {
                string json = "{\"action\":\"recognition\",\"command\":\"event\",\"eventid\":[\"1108\"],\"from_ip\":\"192.168.0.49\",\"user\":\"safetymaster\"}\n";
                json = json.Replace("\n", "");
                RootObject m = JsonConvert.DeserializeObject<RootObject>(json);
                string ipAddress = m.from_ip;
                string eventID = m.eventid[0];
    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
    
        }
    }
