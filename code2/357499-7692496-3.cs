        private void userControl11_MouseMove(object sender, MouseEventArgs e) {
            Console.WriteLine("On shape {0}", e.Location);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            Console.WriteLine("On form  {0}", e.Location);
        }
