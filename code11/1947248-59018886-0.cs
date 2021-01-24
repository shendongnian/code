    class Foo
    {
        public string Name { get; set; }
        public bool HasName => !String.IsNullOrEmpty(Name);  ////assume you want empty to be treated same way as null
        public void NameToUpperCase()
        {
            if (HasName)
            {
                Name = Name.ToUpper();
            }
        }
    }
