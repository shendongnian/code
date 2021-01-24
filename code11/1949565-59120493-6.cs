    namespace Business
    {
        using System;
        public class Dispatching
        {
            public string Send(string delivery)
            {
                return $"Delivery '{delivery}' sent at {DateTime.Now:dd-MM-yyyy HH:mm}";
            }
        }
    }
