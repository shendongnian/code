    class Print : IPrint
        {
            void IPrint.Print(byte[] content)
            {
                Print_UWP printing = new Print_UWP();
                printing.PrintUWpAsync(content);
            }
        }
