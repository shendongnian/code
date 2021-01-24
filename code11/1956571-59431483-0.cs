    public interface IMyInterface {
      public Company Company { get; }
      public string Name { get; }
      public string SurName { get; }
    }
    public class IdentDto : IMyInterface {
        public string Name { get => User.Name; }
        public string SurName { gt => User.SurName; }
    }
    public class User: IMyInterface { }
