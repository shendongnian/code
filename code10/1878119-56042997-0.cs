    public interface IEntity
    {
        IEntity FindById(int Id);
    }
    public class ClassA : IEntity
    {
        IEntity IEntity.FindById(int Id)
        {
            IEntity returnvalue = null;
            //do some specific stuff to get the entity
            return returnvalue;
        }
    }
    public class ClassB : IEntity
    {
        IEntity IEntity.FindById(int Id)
        {
            IEntity returnvalue = null;
            //do some specific stuff to get the entity
            return returnvalue;
        }
    }
    public class ClassC : IEntity
    {
        IEntity IEntity.FindById(int Id)
        {
            IEntity returnvalue = null;
            //do some specific stuff to get the entity
            return returnvalue;
        }
    }
    public static class TestClass
    {
        public static void Test()
        {
            IEntity EA = new ClassA();
            IEntity EB = new ClassB();
            IEntity EC = new ClassC();
            EA.FindById(1);
            EB.FindById(2);
            EB.FindById(3);
        }
    }
