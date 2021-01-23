    Class Cat : BaseLibraryClass
    {
        public string Name;
        public Collar MyCollar;
        public override object DeepCopy()
        {
            Cat destination = new Cat();
            Cat.Name = Name;
            Cat.MyCollar = MyCollar.DeepCopy();
        }
    }
    Class Collar { ... }
