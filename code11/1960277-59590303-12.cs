 5. I made a base class BaseEvent with common properties (in this case just Timestamp)
 6. I made sub classes of the BaseEvent for each event, i.e.  RankEvent
 7. I made an event enum EventType to parse the "event" property.
 8. I looped through all lines, for each line I Deserialize the line into a JsonEvent C# class (jsonEvent) and looked at the EventType to know which sub class I should create.
 9. I add each parsed/deserialized sub class (newEvent) into a list of ```List<BaseEvent>``` baseEvents
 10. When the loop is done, the baseEvents variable is populated and ready to be used in the rest of the program.
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
namespace StackOverFlow
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileName = @"X:\Log Files\01.log";
            var baseEvents = ParseEvents(fileName);
        }
        private static List<BaseEvent> ParseEvents(string fileName)
        {
            var baseEvents = new List<BaseEvent>();
            var lines = File.ReadAllLines(fileName).ToList();
            foreach (var line in lines)
            {
                var jsonEvent = JsonConvert.DeserializeObject<JsonEvent>(line);
                BaseEvent newEvent;
                switch (jsonEvent.EventType)
                {
                    case EventType.Rank:
                        newEvent = new RankEvent(jsonEvent);
                        baseEvents.Add(newEvent);
                        break;
                    case EventType.Progress:
                        newEvent = new ProgressEvent(jsonEvent);
                        baseEvents.Add(newEvent);
                        break;
                    case EventType.Reputation:
                        newEvent = new ReputationEvent(jsonEvent);
                        baseEvents.Add(newEvent);
                        break;
                    case EventType.Music:
                        newEvent = new MusicEvent(jsonEvent);
                        baseEvents.Add(newEvent);
                        break;
                    default:
                        break;
                }
            }
            return baseEvents;
        }
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventType
    {
        [EnumMember(Value = "Rank")]
        Rank,
        [EnumMember(Value = "Progress")]
        Progress,
        [EnumMember(Value = "Reputation")]
        Reputation,
        [EnumMember(Value = "Music")]
        Music,
    }
    public abstract class BaseEvent
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
        public EventType EventType { get; set; }
        public int? Rank1 { get; set; }
        public int? Rank2 { get; set; }
        public int? Task1 { get; set; }
        public int? Task2 { get; set; }
        public double? Nation { get; set; }
        public double? State { get; set; }
        public string MusicTrack { get; set; }
    }
}
baseEvents:
[![enter image description here][4]][4]
**Additional reading:** 
**Parse Json to C#**
https://stackoverflow.com/questions/6620165/how-can-i-parse-json-with-c
https://www.jerriepelser.com/blog/deserialize-different-json-object-same-class/
**Debugging in Visual Studio** 
(always set a breakpoint on a line with F9, then hit F5 and step through your code with F10/F11, it gives much insight into how the code behaves) 
https://docs.microsoft.com/en-us/visualstudio/debugger/navigating-through-code-with-the-debugger?view=vs-2019
**Tools for creating C# classes from Json:**
https://app.quicktype.io/#l=cs&r=json2csharp
https://marketplace.visualstudio.com/items?itemName=DangKhuong.JSONtoC
  [1]: https://app.quicktype.io/#l=cs&r=json2csharp
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/built-in-types-table
  [3]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types
  [4]: https://i.stack.imgur.com/SBRrI.png
