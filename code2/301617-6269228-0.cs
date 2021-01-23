    public interface IFoo {
        int Id { get; set; }
    }
    public static Dictionary<string, T> GetTabStates<T>() where T : new(), IFoo {
       T Tval = new T();
       Tval.Id = 1;
       //etc       
