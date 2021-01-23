    /// <summary>
    /// Dog.
    /// </summary>
    class Dog : Animal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dog"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public Dog(string type)
            : base(type)
        { }
        /// <summary>
        /// Gets a dog from an animal.
        /// </summary>
        /// <param name="animal">The animal.</param>
        /// <returns></returns>
        public static Dog FromAnimal(Animal animal)
        {
            return new Dog(animal.Type);
        }
    }
    /// <summary>
    /// Animal.
    /// </summary>
    class Animal
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Animal"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public Animal(string type)
        {
            this.Type = type;
        }
    }
