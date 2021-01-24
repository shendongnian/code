     public class Animal
     {
        #region | Enums |
        
        public enum AnimalType
        {
            Dog = 0,
            Cat = 1,
        }
        #endregion
        #region | Properties |
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public float Happiness { get; set; } = 0f;
        public AnimalType Animaltype { get; set; } = AnimalType.Dog;
        #endregion
        #region | Constructor |
        public Animal(string name, int age, float happiness, AnimalType animalType)
        {
            Name = name;
            Age = age;
            Happiness = happiness;
            Animaltype = animalType;
        }
        #endregion
        #region | Overrides |
        public override string ToString()
        {
            return Name + Environment.NewLine + Age.ToString() + Environment.NewLine + Happiness.ToString() + Environment.NewLine() + Animaltype.ToString();
        }
        #endregion
    }
