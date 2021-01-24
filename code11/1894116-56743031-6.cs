    public class UserClassAttribute : Attribute {
    }
    
    public class Spell {
        public string name { get; set; }
        public string description { get; set; }
        [UserClass]
        public string sor { get; set; }
        [UserClass]
        public string wiz { get; set; }
        [UserClass]
        public string cleric { get; set; }
    }
    
    void BuildAccessSpellClass() {
        var members = typeof(Spell).GetProperties();
        AccessSpellClass = new Dictionary<string, Func<Spell, string>>();
        foreach (var p in members) {
            if (p.GetCustomAttribute(typeof(UserClassAttribute)) != null) {
                var className = p.Name;
                var parmS = Expression.Parameter(typeof(Spell), "s");
                var body = Expression.MakeMemberAccess(parmS, p);
                var accessExpr = Expression.Lambda<Func<Spell,string>>(body, parmS);
                AccessSpellClass.Add(className, accessExpr);
            }
        }
    }
