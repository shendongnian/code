    public class Calling
    {
        private readonly IEnumerable<IProductValidator> _productValidators;
        public Calling(IEnumerable<IProductValidator> productValidators)
        {
            _productValidators = productValidators;
        }
        public void Validate(string productCode, string keyCode)
        {
            //find the right validator based on productCode
            var validator = _productValidators.Where(v => v.CanProcess(productCode));
            validator.Validate(keyCode);
        }
    }
