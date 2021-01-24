    [Serializable]
    public class ProductViewModel
    {
       public int Id { get; set; }
       public ICollection<ProductFeatureViewModel> Features { get; set;} = new List<ProductFeatureViewModel>();
    }
    [Serializable]
    public class ProductFeatureViewModel
    {
       public int Id { get; set; }
       public string Feature { get; set; }
    }
