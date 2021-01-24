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
                    var eventType = JsonConvert.DeserializeObject<EventType>(line);
                    BaseEvent newEvent;
                    switch (eventType.@event)
                    {
                        case "Rank":
                            newEvent = new RankEvent(eventType);
                            baseEvents.Add(newEvent);
                            break;
                        case "Progress":
                            newEvent = new ProgressEvent(eventType);
                            baseEvents.Add(newEvent);
                            break;
                        case "Reputation":
                            newEvent = new ReputationEvent(eventType);
                            baseEvents.Add(newEvent);
                            break;
                        case "Music":
                            newEvent = new MusicEvent(eventType);
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
            public RankEvent(EventType eventType) : base(eventType.timestamp)
            {
                Rank1 = eventType.Rank1.Value;
                Rank2 = eventType.Rank2.Value;
            }
            public int Rank1 { get; set; }
            public int Rank2 { get; set; }
        }
    
        public class ProgressEvent : BaseEvent
        {
            public ProgressEvent(EventType eventType) : base(eventType.timestamp)
            {
                Task1 = eventType.Task1.Value;
                Task2 = eventType.Task2.Value;
            }
            public int Task1 { get; set; }
            public int Task2 { get; set; }
        }
    
        public class ReputationEvent : BaseEvent
        {
            public ReputationEvent(EventType eventType) : base(eventType.timestamp)
            {
                Nation = eventType.Nation.Value;
                State = eventType.State.Value;
            }
            public double Nation { get; set; }
            public double State { get; set; }
        }
    
        public class MusicEvent : BaseEvent
        {
            public MusicEvent(EventType eventType) : base(eventType.timestamp)
            {
                MusicTrack = eventType.MusicTrack;
            }
            public string MusicTrack { get; set; }
        }
    
        public class EventType
        {
            public DateTime timestamp { get; set; }
            public string @event { get; set; }
            public int? Rank1 { get; set; }
            public int? Rank2 { get; set; }
            public int? Task1 { get; set; }
            public int? Task2 { get; set; }
            public double? Nation { get; set; }
            public double? State { get; set; }
            public string MusicTrack { get; set; }
        }
    }
