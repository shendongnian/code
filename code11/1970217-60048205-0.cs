    public interface IProductValidator
    {
        bool CanProcess(string productCode);
        void Validate(string keyCode);
    }
