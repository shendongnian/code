    class Skill
    {
        public string Name { get; set; }
        public string KeyAbility { get; set; }
        public int SkillModifier { get; set; }
        public int AbilityModifier { get; set; }
        public int Ranks { get; set; }
        public int MiscModifier { get; set; }
        void Calculate()
        {
            //Formula goes here
            //Set the SkillModifier
        }
    }
    Skill balance = new Skill() { Name = "Balance" }
