            class Game
        {
            public int GameID { get; set; }
            public string GameName { get; set; }
            public int GameMaxPlayers { get; set; }
            public int GamePrize { get; set; }
            public List<string> GamePlayers = new List<string>();
        }
            private void BTN1_Click(object sender, RoutedEventArgs e)
        {
            StackPanel SPanel = new StackPanel();
            TextBlock TXTB1 = new TextBlock();
            TextBlock TXTB2 = new TextBlock();
            TextBlock TXTB3 = new TextBlock();
            TextBlock TXTB4 = new TextBlock();
            ListBox LBox1 = new ListBox();
            Game AddGame = new Game();
            AddGame.GameID = 10;
            AddGame.GameName = "Football";
            AddGame.GameMaxPlayers = 16;
            AddGame.GamePrize = 10000;
            AddGame.GamePlayers.Add("Test1"); AddGame.GamePlayers.Add("Test2"); AddGame.GamePlayers.Add("Test3");
            TXTB1.Margin = new Thickness(10); TXTB1.FontSize = 26;
            TXTB1.HorizontalAlignment = HorizontalAlignment.Center; TXTB1.VerticalAlignment = VerticalAlignment.Center;
            TXTB1.Text = AddGame.GameID.ToString();
            TXTB2.FontSize = 26; TXTB2.Background = Brushes.Black; TXTB2.Foreground = Brushes.White; 
            TXTB2.HorizontalAlignment = HorizontalAlignment.Stretch; TXTB2.VerticalAlignment = VerticalAlignment.Stretch;
            TXTB2.Text = AddGame.GameName;
            TXTB3.FontSize = 26; TXTB3.Margin = new Thickness(10);
            TXTB3.HorizontalAlignment = HorizontalAlignment.Center; TXTB3.VerticalAlignment = VerticalAlignment.Center;
            TXTB3.Text = AddGame.GameMaxPlayers.ToString();
            TXTB4.FontSize = 26; TXTB4.Margin = new Thickness(10);
            TXTB4.HorizontalAlignment = HorizontalAlignment.Center; TXTB4.VerticalAlignment = VerticalAlignment.Center;
            TXTB4.Text = "$ " + AddGame.GamePrize.ToString();
            foreach (string s in AddGame.GamePlayers)
            {
                LBox1.Items.Add(s);
            }
            SPanel.Children.Add(TXTB1); SPanel.Children.Add(TXTB2); SPanel.Children.Add(TXTB3); SPanel.Children.Add(TXTB4); SPanel.Children.Add(LBox1);
            ListView1.Items.Add(SPanel);
        }
