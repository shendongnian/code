    class Program
    {
        public static void Main()
        {
            var str = "{ LevelConfig : \"level.json\"}";
            var levelConfigs = JsonConvert.DeserializeObject<LevelConfigs>(str);
            var fileTxt = GetFileText(levelConfigs.LevelConfig);
            JLevel level = JsonConvert.DeserializeObject<JLevel>(fileTxt);
            Console.WriteLine(level.HpScale);
            Console.ReadLine();
        }
        private static string GetFileText(string jsonFile)
        {
            return File.ReadAllText(jsonFile);
        }
    }
    public class LevelConfigs
    {
        public string LevelConfig { get; set; }
    }
    public class JLevel
    {
        public float SkillGain { get; set; }
        public float MagicGain { get; set; }
        public float XpScale { get; set; }
        public float HpScale { get; set; }
        public float MpScale { get; set; }
    }
    public class JEntity
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int Xp { get; set; }
        public JLevel LevelConfig { get; set; }
        
    }
