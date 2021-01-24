    using System.IO;
    using Newtonsoft.Json;
    
    namespace TestEnvironmentVariable
    {
        public static class SettingsUtil
        {
            public static T GetObjectFromJsonFile<T>(string filename)
            {
                string json = File.ReadAllText(filename);
                var deserializedObject = JsonConvert.DeserializeObject<T>(json);
    
                return deserializedObject;
            }
        }
    }
