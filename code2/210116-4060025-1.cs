    public class Issue
    {
       public int Id{ get; set; }
       public IHazIssues Parent { get; set; } //If you really need this
       public string Name { get; set; }
       public string Description { get; set; }
    }
    
    public class Customer : IHazIssues 
    {
       public int Id{ get; set; }
       public IList<Issue> Issues { get; set; }
       public string NAme{ get; set; }
    }
    
    //If you don't need the parent mapping on Item you don't need this.
    public interface IHazIssues 
    {
       IList<Issue> Issues { get; set; }
    }
