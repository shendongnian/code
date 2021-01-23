    public class Movie {
        public string Name;
        public Actor LeadActor;
        public static Movie FromXml (XElement x)
        {
            Movie m = new Movie();
            m.Name = x.Element("Name").Value;
            m.LeadActor = Actor.FromXml(x.Element("LeadActor"));
            return m;
        }
    }
    
    public class Actor {
        public string Name;
        public DateTime DOB;
        public static Actor FromXml (XElement x)
        {
            Actor a = new Actor();
            a.Name = x.Value;
            a.DOB = ... 
            return a;
        }
    }
