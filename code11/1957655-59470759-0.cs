public class Category
{
   public Category()
  {
    SubCategories = new HashSet<Category>();
  }
    public int ID { get; set; }
    public string Name { get; set; }
    public int? ParentID { get; set; }
    [Foreignkey ("ParentId")]
    public Category Parent {get; set;}
    public ICollection<Category> SubCategories { get; set; }
}
Then you can start querying where parentid is null then navigate to SubCategories.
