    class Program
    {
        static string feedback; // string to store formatted string, use type Feedback to store the variable itself
    
        static void Main(string[] args)
        {
            service.Feedback += (s,f) => feedback = String.Format("Feedback - Timestamp: {0} - DeviceId: {1}", f.Timestamp, f.DeviceToken);
        }
    }
