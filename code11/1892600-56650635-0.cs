    public interface IPersonService
        {
            string Name { get; set; }
        }
    
        public class PersonService : IPersonService
        {
            Person _personModel = new Person();
            public string Name
            {
                get
                {
                    return _personModel.Name;
                }
                set
                {
                    _personModel.Name = value;
                }
            }
        }
