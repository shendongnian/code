        public void StartManagementConsole()
        {            
            ThreadStart start = delegate
            {
                _managementConsole = new ManagementConsole();
                Application.Run(_managementConsole);
            };
            consoleThread = new Thread(start);
            consoleThread.SetApartmentState(ApartmentState.STA);
            consoleThread.Start();
        }
