    [DataContract(Namespace = "")]
    public class Game
    {
        [XmlArray("Levels")]
        public List<GameLevel> Levels { get; set; }
    }
    [DataContract(Name = "GameLevel", Namespace = "")]
    public class GameLevel
    {
        [XmlAttribute("number")]
        public int Number { get; set; }
        public GameLevelSettings Settings { get; set; }
        [XmlArray("Blocks")]
        [XmlArrayItem("Block")]
        public List<LevelBlock> Blocks { get; set; }
    }
    public class GameLevelDimensions
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }
    public class GameLevelSettings
    {
        public string Name { get; set; }
        public GameLevelDimensions Dimensions { get; set; }
    }
    public class LevelBlock
    {
        [XmlAttribute("Position")]
        public int Position { get; set; }
        [XmlAttribute("GapHeight")]
        public int GapHeight { get; set; }
    }
    internal class XmlGameConfiguration : IGameConfiguration
    {
        private const string ConfigFileName = "game.config";
        public XmlGameConfiguration(string configFilePath)
        {
            using (var stream = new FileStream(configFilePath, FileMode.Open))
            {
                var ser = new XmlSerializer(typeof(Game));
                Game = (Game) ser.Deserialize(stream);
            }
        }
        public XmlGameConfiguration() : this(ConfigFileName)
        {}
        
        public Game Game { get; private set; }
    }
