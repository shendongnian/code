    public class Person
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; private set; }
        public virtual void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new DomainException("Name cannot be empty");
            }
            if (newName.Length > 20)
            {
                throw new DomainException("Name cannot exceed 20 characters");
            }
            this.Name = newName;
        }
    }
