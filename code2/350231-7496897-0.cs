    // You may not want it to be internal, and you may not want it to be sealed -
    // but you should think about both decisions.
    internal sealed class Character
    {
        private readonly string name;
        internal Character(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            this.name = name;
        }
        internal string Name { get { return name; } }
    }
