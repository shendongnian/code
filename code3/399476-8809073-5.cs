    public class Admonisher
    {
        public void Admonish(IEnumerable<Naughty> followers)
        {
            foreach(var follower in followers) { follower.Chastise(); }
        }
    
        public void Admonish(IEnumerable<Obedient> followers)
        {
            foreach(var follower in followers) { follower.Encourage(); }
        }
    }
    internal static void Sanitize(dynamic enumerable)
    {
        dynamic admonisher = new Admonisher();
        admonisher.Admonish(enumerable);
    }
