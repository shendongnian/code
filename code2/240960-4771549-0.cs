    public enum CategoryType 
    {
        Sports, Entertainment, Game, Round
    }
    
    public interface ICategoryBuilder
    {
        void Create();
    }
    
    public class Pool
    {
        public ICategoryBuilder CategoryBuilder { get; set; }
        public CategoryType Category { get; set; }
    }
