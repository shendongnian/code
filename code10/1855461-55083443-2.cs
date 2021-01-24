    {
        "LevelConfig" : {
            "SkillGain" : 0.01,
            "MagicGain" : 0.01,
            "XpScale"   : 50.0,
            "HpScale"   : 0.01,
            "MpScale"   : 0.01
        }
    }
 
    public class LevelConfig
        {
            public double SkillGain { get; set; }
            public double MagicGain { get; set; }
            public double XpScale { get; set; }
            public double HpScale { get; set; }
            public double MpScale { get; set; }
        }
    
        public class Example
        {
            public LevelConfig LevelConfig { get; set; }
        }
