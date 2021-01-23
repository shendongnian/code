    public class Pair
    {
         public string ID { get; set; }
         public string Name { get; set; }
    }
    
    [WebMethod]
    public IList<Pair> SkillsList(string like)
    {
        IList<Skills> mySkills = new List<Skills>();
        IList<Pair> output = new List<Pair>();
        mySkills = Skills.GetSkillsList(like);
    
        foreach(Skills currentSkill in mySkills)
        {
            Pair p = new Pair();
            p.ID = currentSkill.ID;
            p.Name = currentSkill.Name;
    
            output.Add(p);
        }
    
        return output;
    }
