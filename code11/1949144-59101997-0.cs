            private void LoadSecondWindow(object o)
        {
            GameMode gameMode = (GameMode)o;
            Table blackjackTable = new Table(gameMode);
            blackjackTable.Show();
            Dispatcher.Run();
        }
