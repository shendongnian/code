    public class Car
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string ImagePath { get; set; }
    }
    public class CarViewModel
    {
        public string CarName { get; set; }
        public IFormFile Image { get; set; }
    }
