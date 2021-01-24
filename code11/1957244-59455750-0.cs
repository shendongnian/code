    public interface IAnimal
    {
        static void SetDefaultName(string name)
        {
            ChangeName(name);
        }
        private static string defaultName = "NoName";
        private static void ChangeName(string name)
        {
            defaultName = name;
        }
        void Breath()
        {
            Console.WriteLine($"Default - I'm {defaultName}. <Breathing sounds>");
        }
        void Sound();
    }
