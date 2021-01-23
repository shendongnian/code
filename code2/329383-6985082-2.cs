    public interface IHasLastUpdate
    {
        DateTime LastUpdate { get; set; }
    }
    partial class Order : IHasLastUpdate {}
    partial class Product : IHasLastUpdate {}
    // etc
