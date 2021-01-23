    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Windows.Forms;
    namespace ImageServer
    {
        static class Program
        {
            static void Main()
            {
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Bind(new IPEndPoint(IPAddress.Any, 23456));
                    socket.Listen(100);
                    while (true)
                    {
                        using (var client = socket.Accept())
                        {
                            var bounds = Screen.PrimaryScreen.Bounds;
                            var bitmap = new Bitmap(bounds.Width, bounds.Height);
                            try
                            {
                                while (true)
                                {
                                    using (var graphics = Graphics.FromImage(bitmap))
                                    {
                                        graphics.CopyFromScreen(bounds.X, 0, bounds.Y, 0, bounds.Size);
                                    }
                                    byte[] imageData;
                                    using (var stream = new MemoryStream())
                                    {
                                        bitmap.Save(stream, ImageFormat.Png);
                                        imageData = stream.ToArray();
                                    }
                                    var lengthData = BitConverter.GetBytes(imageData.Length);
                                    if (client.Send(lengthData) < lengthData.Length) break;
                                    if (client.Send(imageData) < imageData.Length) break;
                                    Thread.Sleep(1000);
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
