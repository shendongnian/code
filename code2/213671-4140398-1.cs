    public class CarViewModelService
    {
        private readonly CarRepository carRepository;
        private readonly PriceService priceService;
        public CarViewModelService(CarRepository cr, PriceService ps) { ... }
        public CarViewModel GetCarData(int carID)
        {
            var car = carRepository.GetCar(carID);
            decimal lowestPrice = priceService.GetLowestPrice(car.ModelNumber);
            decimal highestPrice = priceService.GetHighestPrice(car.ModelNumber);
            return new CarViewModel { Car = car, LowestPrice = lowestPrice,
                HighestPrice = highestPrice };
        }
    }
