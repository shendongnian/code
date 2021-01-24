    public static async void Click()
            {
                StreamReader reader = new StreamReader(@"D:\Bhushan\a.txt");
                var fileContent = await reader.ReadToEndAsync();
            }
