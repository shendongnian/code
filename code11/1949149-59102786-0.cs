        namespace RegexTests
    {
        static class StringExtension
        {
            public static T DeserializeJson<T>(this string toSerialize)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(toSerialize, new Newtonsoft.Json.JsonSerializerSettings()
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
                });
            }
        }
    
        class Root
        {
            public CodeDependency CodeDependency { get; set; }
        }
    
        class CodeDependency
        {
            public string Path { get; set; }
            public DependencyType Type { get; set; }
        }
    
        enum DependencyType
        {
            NONE = 0,
            TAR = 1,
            ZIP = 2,
            TAR_GZ = 3,
            DIRECTORY = 4,
        }
    
        class Program
        {
    
    
            static void Main(string[] args)
            {
                string json = "{\"CodeDependency\": { \"Path\": \"/CAP_TEST/job_manager/modules/1c8185d5-2add-4bd4-a332-8b21a6819608/tmpr9z7xinh.tar.gz\", \"Type\": \"TAR_GZ\" } }";
    
    
                var obj = json.DeserializeJson<Root>();
    
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
