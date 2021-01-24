    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        public class Car
        {
    
            public IFormFile Imagem1 { get; set; }
            public IFormFile Imagem2 { get; set; }
            public IFormFile Imagem3 { get; set; }
            //and etc
        }
    
        public class Example
        {
            public static void Main()
            {
                List<IFormFile> imagens = new List<IFormFile>();
    
                var car = new Car();
    
                var carType = car.GetType();
                var ifromFileProperties = carType.GetProperties().Where(x => x.GetType() == typeof(IFormFile)).ToArray();
    
                foreach (var property in ifromFileProperties)
                {
                    var image = (IFormFile)property.GetValue(car, null);
                    imagens.Add(image);
                }
            }
        }
    }
