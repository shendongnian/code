    public async Task<bool> Foo()
        {
           return await Task.Run(() =>
           {
               for (int i = 0; i < 100000; i++)
               {
                   Console.WriteLine("Loop");
               }
               return true;
           });
        }
