    public interface IFollower
    {
        void Preach();
    }
    public class Naughty : IFollower {...}
    public class Obedient : IFollower {...}
    public static void Admonish(this IEnumerable<IFollower> followers)
    {
        foreach(var follower in followers) { follower.Preach(); }
    }
    internal static void Sanitize(IEnumerable enumerable)
    {
        enumerable.Cast<IFollower>().Admonish();
    }
