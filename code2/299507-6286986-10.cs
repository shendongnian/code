    public static class ConversionExtensions
    {
        public static CarJson ToCarJson(this Car car)
        {
            return new CarJson {...};
        }
    }
    CarRepository.GetCars().Select(car => car.ToCarJson());
