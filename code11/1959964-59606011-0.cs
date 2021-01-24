    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var imgBody = "<body value here>";
                byte[] bytes = Convert.FromBase64String(imgBody);
                using (Image image = Image.FromStream(new MemoryStream(bytes)))
                {
                    image.Save("d:/test.jpg", ImageFormat.Jpeg);
                }
            }
        }
    }
