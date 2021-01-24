        MainMap.MouseDown += MainMap_MouseDown;
        MainMap.MouseUp += MainMap_MouseUp;
        private void MainMap_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Map Mouse Up");
        }
        private void MainMap_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Map Mouse Down <-- Something going on in here");
        }
