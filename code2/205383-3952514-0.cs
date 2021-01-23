        public static void StartChatWindow()
        {
            Thread thread = new Thread(() =>
            {
                ChatWindow chatWindow = new ChatWindow();
                chatWindow.Chat(); // Do your stuff here, may pass some parameters
                chatWindow.Closed += (sender2, e2) =>
                    // Close the message pump when the window closed
                chatWindow.Dispatcher.InvokeShutdown();
                // Run the message pump
                System.Windows.Threading.Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
