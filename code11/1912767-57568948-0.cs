        public interface Validations
    {
        void ValidationsStuff();
    }
    public class ValidationsWithStorage : Validations
    {
        public void ValidationsStuff()
        {
            //do something
        }
    }
    public class TestsValidations : Validations
    {
        public void ValidationsStuff()
        {
            //do something
        }
    }
    public class ValidationsFactory
    {
        public Validations geValidationsComponent(string useStorage)
        {
            if (string.IsNullOrEmpty(useStorage))
                return new ValidationsWithStorage();
            else
                return new TestsValidations();
        }
    }
