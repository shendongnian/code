    public interface IHasName
    {
         string Name { get; }
    }
    public partial class MyEntity : IHasName {}
    public partial class MyOtherEntity : IHasName {}
    public static int LengthOfNameHuman (IHasName entity) {
        return entity.Name.Length;
    }
