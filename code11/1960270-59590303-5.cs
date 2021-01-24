    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace StackOverFlow
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var baseEvents = new List<BaseEvent>();
                var lines = File.ReadAllLines(@"X:\Log Files\01.log").ToList();
                foreach (var line in lines)
                {
                    var jsonEvent = JsonConvert.DeserializeObject<JsonEvent>(line);
                    BaseEvent newEvent;
                    switch (jsonEvent.EventType)
                    {
                        case "Rank":
                            newEvent = new RankEvent(jsonEvent);
                            baseEvents.Add(newEvent);
                            break;
                        case "Progress":
                            newEvent = new ProgressEvent(jsonEvent);
                            baseEvents.Add(newEvent);
                            break;
                        case "Reputation":
                            newEvent = new ReputationEvent(jsonEvent);
                            baseEvents.Add(newEvent);
                            break;
                        case "Music":
                            newEvent = new MusicEvent(jsonEvent);
                            baseEvents.Add(newEvent);
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine(baseEvents);
            }
        }
    
        public class BaseEvent
        {
            public BaseEvent(DateTime timestamp)
            {
                Timestamp = timestamp;
            }
            public DateTime Timestamp { get; set; }
        }
        public class RankEvent : BaseEvent
        {
            public RankEvent(JsonEvent jsonEvent) : base(jsonEvent.Timestamp)
            {
                Rank1 = jsonEvent.Rank1.Value;
                Rank2 = jsonEvent.Rank2.Value;
            }
            public int Rank1 { get; set; }
            public int Rank2 { get; set; }
        }
    
        public class ProgressEvent : BaseEvent
        {
            public ProgressEvent(JsonEvent jsonEvent) : base(jsonEvent.Timestamp)
            {
                Task1 = jsonEvent.Task1.Value;
                Task2 = jsonEvent.Task2.Value;
            }
            public int Task1 { get; set; }
            public int Task2 { get; set; }
        }
    
        public class ReputationEvent : BaseEvent
        {
            public ReputationEvent(JsonEvent jsonEvent) : base(jsonEvent.Timestamp)
            {
                Nation = jsonEvent.Nation.Value;
                State = jsonEvent.State.Value;
            }
            public double Nation { get; set; }
            public double State { get; set; }
        }
    
        public class MusicEvent : BaseEvent
        {
            public MusicEvent(JsonEvent jsonEvent) : base(jsonEvent.Timestamp)
            {
                MusicTrack = jsonEvent.MusicTrack;
            }
            public string MusicTrack { get; set; }
        }
    
        [JsonObject]
        public class JsonEvent
        {
            [JsonProperty("timestamp")]
            public DateTime Timestamp { get; set; }
            [JsonProperty("event")]
            public string EventType { get; set; }
            public int? Rank1 { get; set; }
            public int? Rank2 { get; set; }
            public int? Task1 { get; set; }
            public int? Task2 { get; set; }
            public double? Nation { get; set; }
            public double? State { get; set; }
            public string MusicTrack { get; set; }
        }
    }
