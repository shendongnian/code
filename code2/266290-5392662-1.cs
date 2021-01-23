    class Program
    {
        static void Main()
        {
            var myData = new MyData
            {
                GalleryData = new GalleryData
                {
                    Title = "some title",
                    UUID = "32432322",
                    ImagePath = "some path"
                },
                ImageDatas = new[]
                {
                    new ImageData
                    {
                        Title = "title one",
                        Category = "nature",
                        Description = "blah blah"
                    },
                    new ImageData
                    {
                        Title = "title two",
                        Category = "nature",
                        Description = "blah blah"
                    },
                }
            };
    
            var serializer = new XmlSerializer(myData.GetType());
            serializer.Serialize(Console.Out, myData);
        }
    }
