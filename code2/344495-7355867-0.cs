    Dictionary<Skill.Id, Func<Skill>> creationMethods = new Dictionary<Skill.Id, Func<Skill>>();
    public SkillFactory()
    {
         creationMethods.Add(Skill.Id.FireSkill, () => new FireSkill());
         creationMethods.Add(Skill.Id.WaterSkill, () => new WaterSkill());
    }
