    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication3
    {
    class Program
    {
        static void Main(string[] args)
        {
            List<myClass> data = new List<myClass>();
            StringBuilder sb = new StringBuilder();
            data.Add(new myClass() { Height = 3, Width = 10, X = 0, Y = 0, Id = 1 });
            data.Add(new myClass() { Height = 5, Width = 10, X = 10, Y = 0, Id = 2 });
            data.Add(new myClass() { Height = 2, Width = 10, X = 20, Y = 0, Id = 3 });
            data.Add(new myClass() { Height = 6, Width = 10, X = 0, Y = 3, Id = 4 });
            data.Add(new myClass() { Height = 3, Width = 10, X = 0, Y = 5, Id = 5 });
            data.Add(new myClass() { Height = 8, Width = 10, X = 0, Y = 2, Id = 6 });
            List<myClass> result = GetVisualRegions(data);
            var dataSortW = from item in result
                            orderby item.Width descending
                            select item;
            var dataSortH = from item in result
                            orderby item.Height descending
                            select item;
            Console.WriteLine("Data sorted by Width");
            foreach (var item in dataSortW)
                Console.WriteLine(item.Id);
            Console.WriteLine("Data sorted by Height");
            foreach (var item in dataSortH)
                Console.WriteLine(item.Id);
            Console.ReadLine();
        }
        
        private static List<myClass> GetVisualRegions(List<myClass> data)
        {
            int maxX = data.Max(obj => obj.X + obj.Width);
            int maxY = data.Max(obj => obj.Y + obj.Height);
            int[,] dataOverlapping = new int[maxX, maxY];
            List<myClass> result = new List<myClass>();
            foreach (var item in data)
            {
                myClass tmpItem = new myClass();
                bool yColected = false;
                int xdata = item.X + item.Width;
                int ydata = item.Y + item.Height;
                int id = item.Id;
                tmpItem.Id = item.Id; ;
                for (int posY = item.Y; posY < ydata; posY++)
                {
                    int width = 0;
                    for (int posX = item.X; posX < xdata; posX++)
                    {
                        if (dataOverlapping[posX, posY] <= 0)
                        {
                            dataOverlapping[posX, posY] = id;
                            width += 1;
                            if (yColected == false)
                            {
                                yColected = true;
                                tmpItem.Height += 1;
                            }
                        }
                    }
                    yColected = false;
                    if (tmpItem.Width < width)
                        tmpItem.Width = width;
                }
                if ((tmpItem.Height > 0) && (tmpItem.Width > 0))
                    result.Add(tmpItem);
            }
            return result;
        }
    }
    public class myClass
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
