    private static void OpenWindow()
            {
                //Exception(Cannot create more than one System.Windows.Application instance in the same AppDomain.)
                //is thrown at the second iteration.
                var app = new System.Windows.Application();
                var window = new System.Windows.Window();
                app.Run();
                window.Show();
                //User  closes the opened window manually.
            }
