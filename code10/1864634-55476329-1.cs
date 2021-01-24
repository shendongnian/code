        public Broadcaster()
        {
            mission.OnMissionStart += (sender) =>
            {
                Console.WriteLine($"This is {sender.Name}");
                Console.WriteLine($"Additional info: {sender.AdditionalInfo}");
            };
        }
