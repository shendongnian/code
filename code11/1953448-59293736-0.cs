        public static class Program
        {
            static void Main()
            {
                Explore("C:\\Users\\art_g\\Desktop\\Sample.txt");
            }
            static void Explore(string path) =>
                Process.Start("explorer.exe", "/select, " + path);
        }
