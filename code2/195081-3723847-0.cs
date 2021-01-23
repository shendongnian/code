    public class AbstractFactoryExample
    {
        public AbstractFactoryExample()
        {
            string type = "";
            CarFactory facotry=null;
            if (type == "FORD")
            {
                facotry = new FordCarFactory();
            }
            ICar MyFamilyCar = facotry.CreateFamilyCar();
            ICar MyCityCar = facotry.CreateCityCar();
        }
    }
    public interface ICar
    {
    }
    public abstract class CarFactory
    {
        public  abstract ICar CreateFamilyCar();
        public  abstract ICar CreateCityCar();
    }
    public class FordCarFactory : CarFactory
    {
        public  override ICar  CreateFamilyCar()
        {
            return new FordFamilyCar();
        }
        public override ICar CreateCityCar()
        {
            return new FordCityCar();
        }
    }
    public class FordFamilyCar : ICar
    {
    }
    public class FordCityCar : ICar
    {
    }
