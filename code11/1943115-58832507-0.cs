class Program
    {
        public class Image
        {
            public string Name { get; set; }
            public Image(string name)
            {
                Name = name;
            }
        }
        public class ImageWithIndex : Image
        {
            public SortedImage(string name, int index) : base(name)
            {
                Index = index;
            }
            public int Index { get; set; }
        }
        static void Main(string[] args)
        {            
            var images = new List<List<Image>>
            {
                new List<Image> { new Image("1"), new Image("2"), new Image("3") },
                new List<Image> {  new Image("4"), new Image("5"), new Image("6"), new Image("7") },
                new List<Image> {  new Image("8"), new Image("9") }
            };
            var sortedList = images
                .SelectMany(innerList => innerList.Select((image, index) => new ImageWithIndex(image.Name, index)))
                .OrderBy(i => i.Index)
                .Select(i => i as Image);
        }
    }
