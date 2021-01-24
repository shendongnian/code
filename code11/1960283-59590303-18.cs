 5. I made a base class BaseEvent with common properties (in this case just Timestamp)
 6. I made sub classes of the BaseEvent for each event, i.e.  RankEvent
 7. I made an event enum EventType to parse the "event" property.
 8. I looped through all lines, for each line I Deserialize the line into a JsonEvent C# class (jsonEvent) and looked at the EventType to know which sub class I should create.
 9. For each loop, I parsed/deserialized a sub class (newEvent) into a list of ```List<BaseEvent>``` eventList
 10. When the loop is done, the eventList variable is populated and ready to be used in the rest of the program.
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
            var file = @"X:\Log Files\01.log";
            var eventList = ParseEvents(file);
            //TODO Do something
        }
        private static List<BaseEvent> ParseEvents(string file)
        {
            //TODO Encapsulate in a try & catch and add a logger for error handling
            var eventList = new List<BaseEvent>();
            var lines = File.ReadAllLines(file).ToList();
            foreach (var line in lines)
            {
                var jsonEvent = JsonConvert.DeserializeObject<JsonEvent>(line);
                BaseEvent newEvent;
                switch (jsonEvent.EventType)
                {
                    case EventType.Rank:
                        newEvent = new RankEvent(jsonEvent);
                        eventList.Add(newEvent);
                        break;
                    case EventType.Progress:
                        newEvent = new ProgressEvent(jsonEvent);
                        eventList.Add(newEvent);
                        break;
                    case EventType.Reputation:
                        newEvent = new ReputationEvent(jsonEvent);
                        eventList.Add(newEvent);
                        break;
                    case EventType.Music:
                        newEvent = new MusicEvent(jsonEvent);
                        eventList.Add(newEvent);
                        break;
                    //TODO Add more cases for each EventType
                    default:
                        throw new Exception(String.Format("Unknown EventType: {0}", jsonEvent.EventType));
                }
            }
            return eventList;
        }
    }
    //TODO Move classes/enums to a separate folder
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
        //TODO Add more enum values for each "event"
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
    //TODO Add more derived sub classes of the BaseEvent
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
        //TODO Add more properties
    }
}
eventList Quickwatch:
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
-------------------------------------------------------------------
**UPDATE:
I made an additional script that creates the above C# sub classes for you:**
Just run this script and all classes (including Program.cs) will be created. 
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace CreateFiles
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var file = @"X:\Log Files\01.log";
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //Change outPutPath to your choosing
                var outPutPath = Path.Combine(desktop, "Temp");
                //Change namespaceName to your choosing
                var namespaceName = "StackOverFlow";
                var uniqueList = GetUniqueEventTypeList(file);
                CreateBaseClass(outPutPath, namespaceName);
                CreateEventClasses(uniqueList, outPutPath, namespaceName);
                CreateEnumClass(uniqueList, outPutPath, namespaceName);
                CreateJsonEventClass(uniqueList, outPutPath, namespaceName);
                CreateProgramClass(uniqueList, outPutPath, namespaceName);
                Console.WriteLine($"\nParsing done! Classes parsed to {outPutPath}");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
    
            private static List<string> GetUniqueEventTypeList(string file)
            {
                var lines = File.ReadAllLines(file).ToList();
                var uniqueEventTypes = new List<string>();
                var uniqueList = new List<string>();
    
                foreach (var line in lines)
                {
                    var json = JObject.Parse(line);
                    var eventType = json["event"].Value<string>();
                    if (!uniqueEventTypes.Exists(e => e.Equals(eventType)))
                    {
                        uniqueEventTypes.Add(eventType);
                        uniqueList.Add(line);
                    }
                }
                return uniqueList;
            }
    
            private static void CreateEventClasses(List<string> lines, string path, string namespaceName)
            {
                foreach (var line in lines)
                {
                    var jObj = JObject.Parse(line);
                    CreateEventClass(jObj, path, namespaceName);
                }
            }
    
            public class ParseClass
            {
                public ParseClass(KeyValuePair<string, JToken> obj)
                {
                    Name = obj.Key;
                    SetType(obj.Value);
                }
                public string Name { get; set; }
                public string Type { get; set; }
                public bool IsPrimitive { get; set; }
    
                private void SetType(JToken token)
                {
                    switch (token.Type)
                    {
                        case JTokenType.Integer:
                            Type = "int";
                            IsPrimitive = true;
                            break;
                        case JTokenType.Float:
                            Type = "double";
                            IsPrimitive = true;
                            break;
                        case JTokenType.String:
                            Type = "string";
                            IsPrimitive = false;
                            break;
                        case JTokenType.Boolean:
                            Type = "bool";
                            IsPrimitive = true;
                            break;
                        case JTokenType.Date:
                            Type = "DateTime";
                            IsPrimitive = true;
                            break;
                        case JTokenType.Guid:
                            Type = "Guid";
                            IsPrimitive = true;
                            break;
                        case JTokenType.Uri:
                            Type = "Uri";
                            IsPrimitive = false;
                            break;
                        default:
                            throw new Exception($"Unknown type {token.Type}");
                    }
                }
            }
    
            private static void CreateProgramClass(List<string> lines, string path, string namespaceName)
            {
                Directory.CreateDirectory(path);
                var className = "Program";
                var fileName = $"{className}.cs";
                var file = Path.Combine(path, fileName);
    
                try
                {
                    // Create a new file     
                    using (FileStream fsStream = new FileStream(file, FileMode.Create))
                    using (StreamWriter sw = new StreamWriter(fsStream, Encoding.UTF8))
                    {
                        //The Program class needed these bytes in the beginning to work
                        byte[] bytes = new byte[] { 0xef, 0xbb, 0xbf };
                        sw.BaseStream.Write(bytes, 0, bytes.Length);
                        sw.WriteLine("using Newtonsoft.Json;");
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.IO;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("");
                        sw.WriteLine($"namespace {namespaceName}");
                        sw.WriteLine("{");
                        sw.WriteLine($"    public class {className}");
                        sw.WriteLine("    {");
                        sw.WriteLine($"        static void Main(string[] args)");
                        sw.WriteLine("        {");
                        sw.WriteLine("            var file = @\"X:\\Log Files\\01.log\";");
                        sw.WriteLine("            var eventList = ParseEvents(file);");
                        sw.WriteLine("            //TODO Do something");
                        sw.WriteLine("        }");
                        sw.WriteLine("");
                        sw.WriteLine("        private static List<BaseEvent> ParseEvents(string file)");
                        sw.WriteLine("        {");
                        sw.WriteLine("            //TODO Encapsulate in a try & catch and add a logger for error handling");
                        sw.WriteLine("            var eventList = new List<BaseEvent>();");
                        sw.WriteLine("            var lines = File.ReadAllLines(file).ToList();");
                        sw.WriteLine("");
                        sw.WriteLine("            foreach (var line in lines)");
                        sw.WriteLine("            {");
                        sw.WriteLine("                var jsonEvent = JsonConvert.DeserializeObject<JsonEvent>(line);");
                        sw.WriteLine("                BaseEvent newEvent;");
                        sw.WriteLine("                switch (jsonEvent.EventType)");
                        sw.WriteLine("                {");
                        foreach (var line in lines)
                        {
                            var jObj = JObject.Parse(line);
                            var eventType = jObj["event"].Value<string>();
                            sw.WriteLine($"                    case EventType.{eventType}:");
                            sw.WriteLine($"                        newEvent = new {eventType}Event(jsonEvent);");
                            sw.WriteLine($"                        eventList.Add(newEvent);");
                            sw.WriteLine($"                        break;");
                        }
                        sw.WriteLine("                    default:");
                        sw.WriteLine("                        throw new Exception(String.Format(\"Unknown EventType: {0} \", jsonEvent.EventType));");
                        sw.WriteLine("                }");
                        sw.WriteLine("            }");
                        sw.WriteLine("            return eventList;");
                        sw.WriteLine("        }");
                        sw.WriteLine("    }");
                        sw.WriteLine("}");
                    }
                    Console.WriteLine($"Created {fileName}.");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }
            }
    
            private static void CreateEnumClass(List<string> lines, string path, string namespaceName)
            {
                Directory.CreateDirectory(Path.Combine(path));
                var className = "EventType";
                var fileName = $"{className}.cs";
                var file = Path.Combine(path, fileName);
                FileInfo fi = new FileInfo(file);
    
                try
                {
                    // Check if file already exists. If yes, throw exception.     
                    if (fi.Exists)
                    {
                        throw new Exception($"{file} already exists!");
                    }
    
                    // Create a new file     
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine("using Newtonsoft.Json;");
                        sw.WriteLine("using Newtonsoft.Json.Converters;");
                        sw.WriteLine("using System.Runtime.Serialization;");
                        sw.WriteLine("");
                        sw.WriteLine($"namespace {namespaceName}");
                        sw.WriteLine("{");
                        sw.WriteLine($"    [JsonConverter(typeof(StringEnumConverter))]");
                        sw.WriteLine($"    public enum {className}");
                        sw.WriteLine("    {");
                        foreach (var line in lines)
                        {
                            var jObj = JObject.Parse(line);
                            var eventType = jObj["event"].Value<string>();
                            sw.WriteLine($"        [EnumMember(Value = \"{eventType}\")]");
                            sw.WriteLine($"        {eventType},");
                        }
                        sw.WriteLine("    }");
                        sw.WriteLine("}");
                    }
                    Console.WriteLine($"Created {fileName}.");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }
            }
    
            private static void CreateJsonEventClass(List<string> lines, string path, string namespaceName)
            {
    
                Directory.CreateDirectory(path);
                var className = "JsonEvent";
                var fileName = $"{className}.cs";
                var file = Path.Combine(path, fileName);
                FileInfo fi = new FileInfo(file);
    
                var propertyList = new List<ParseClass>();
                foreach (var line in lines)
                {
                    var jObject = JObject.Parse(line);
                    foreach (var obj in jObject)
                    {
                        if (!(obj.Key.Equals("event") || obj.Key.Equals("timestamp")))
                        {
                            propertyList.Add(new ParseClass(obj));
                        }
                    }
                }
    
                try
                {
                    // Check if file already exists. If yes, throw exception.     
                    if (fi.Exists)
                    {
                        throw new Exception($"{file} already exists!");
                    }
                    // Create a new file     
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine("using Newtonsoft.Json;");
                        sw.WriteLine("using System;");
                        sw.WriteLine("");
                        sw.WriteLine($"namespace {namespaceName}");
                        sw.WriteLine("{");
                        sw.WriteLine($"    [JsonObject]");
                        sw.WriteLine($"    public class {className}");
                        sw.WriteLine("{");
                        sw.WriteLine("        [JsonProperty(\"timestamp\")]");
                        sw.WriteLine("        public DateTime Timestamp { get; set; }");
                        sw.WriteLine("        [JsonProperty(\"event\")]");
                        sw.WriteLine("        public EventType EventType { get; set; }");
                        foreach (var property in propertyList)
                        {
                            var type = property.IsPrimitive ? property.Type + "?" : property.Type;
                            sw.WriteLine("        public " + type + " " + property.Name + " { get; set; }");
                        }
                        sw.WriteLine("    }");
                        sw.WriteLine("}");
                    }
                    Console.WriteLine($"Created {fileName}.");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }
            }
    
            private static void CreateBaseClass(string path, string namespaceName)
            {
                Directory.CreateDirectory(path);
                var className = $"BaseEvent";
                var fileName = $"{className}.cs";
                var file = Path.Combine(path, fileName);
    
                FileInfo fi = new FileInfo(file);
    
                try
                {
                    // Check if file already exists. If yes, throw exception.     
                    if (fi.Exists)
                    {
                        throw new Exception($"{file} already exists!");
                    }
    
                    // Create a new file     
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine($"using System;");
                        sw.WriteLine("");
                        sw.WriteLine($"namespace {namespaceName}");
                        sw.WriteLine("{");
                        sw.WriteLine($"    public abstract class BaseEvent");
                        sw.WriteLine("    {");
                        sw.WriteLine($"        public BaseEvent(DateTime timestamp)");
                        sw.WriteLine("        {");
                        sw.WriteLine($"            Timestamp = timestamp;");
                        sw.WriteLine("        }");
                        sw.WriteLine("        public DateTime Timestamp { get; set; }");
                        sw.WriteLine("    }");
                        sw.WriteLine("}");
                    }
                    Console.WriteLine($"Created {fileName}.");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }
            }
    
            private static void CreateEventClass(JObject jObject, string path, string namespaceName)
            {
                Directory.CreateDirectory(path);
                var eventName = $"{jObject["event"].Value<string>()}";
                var className = $"{eventName}Event";
                var fileName = $"{className}.cs";
                var file = Path.Combine(path, fileName);
    
                FileInfo fi = new FileInfo(file);
    
                var propertyList = new List<ParseClass>();
                foreach (var obj in jObject)
                {
                    if (!(obj.Key.Equals("event") || obj.Key.Equals("timestamp")))
                    {
                        propertyList.Add(new ParseClass(obj));
                    }
                }
    
                try
                {
                    // Check if file already exists. If yes, throw exception.     
                    if (fi.Exists)
                    {
                        throw new Exception($"{file} already exists!");
                    }
    
                    // Create a new file     
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine($"namespace {namespaceName}");
                        sw.WriteLine("{");
                        sw.WriteLine($"    public class {className} : BaseEvent");
                        sw.WriteLine("    {");
                        sw.WriteLine($"        public {className}(JsonEvent jsonEvent) : base(jsonEvent.Timestamp)");
                        sw.WriteLine("        {");
                        foreach (var property in propertyList)
                        {
                            var name = property.IsPrimitive ? $"{property.Name}.Value" : $"{property.Name}";
                            sw.WriteLine($"            {property.Name} = jsonEvent.{name};");
                        }
                        sw.WriteLine("        }");
                        foreach (var property in propertyList)
                        {
                            sw.WriteLine("        public " + property.Type + " " + property.Name + " { get; set; }");
                        }
                        sw.WriteLine("    }");
                        sw.WriteLine("}");
                    }
                    Console.WriteLine($"Created {fileName}.");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }
            }
        }
    }
  [1]: https://app.quicktype.io/#l=cs&r=json2csharp
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/built-in-types-table
  [3]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types
  [4]: https://i.stack.imgur.com/VB1L0.png
