    public static class AnimalFactory
    {
        public static Animal CreateAnimal(AnimalInfo aInfo)
        {       
            return aInfo.CreateAnimal();
        }
    }
