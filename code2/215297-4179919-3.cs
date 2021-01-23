        private Window1 win = new Window1();   // say
        private void button1_Click(object sender, RoutedEventArgs e) {
            if (win == null) {
                win = new Window1();
                win.Closing += delegate { win = null; };
            }
            win.ShowDialog();
        }
