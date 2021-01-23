    class Program
    {
        static void Main(string[] args)
        {
            List<ICleanTheRoom> cleanerList = new List<ICleanTheRoom>
                {
                    new Child(), 
                    new Woman(), 
                    new Man()
                };
            foreach (var cleaner in cleanerList)
            {
                cleaner.CleanTheRoom();
            }
        }
    }
    internal interface ICleanTheRoom
    {
        void CleanTheRoom();
    }
    // No need for super type
    //class Human : ICleanTheRoom
    //{
    //   public virtual void CleanTheRoom()
    //   {
    //   }
    //}
    internal class Woman : ICleanTheRoom
    {
        public void CleanTheRoom()
        {
            throw new NotImplementedException();
        }
    }
    class Man: ICleanTheRoom
    {
        public void CleanTheRoom()
        {
            throw new NotImplementedException();
        }
    }
    class Child: ICleanTheRoom
    {
        public void CleanTheRoom()
        {
            throw new NotImplementedException();
        }
    }
