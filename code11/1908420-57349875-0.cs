    public static class Foo
    {
        public static async Task<Int32> Main( String[] args )
        {
            Task loop30 = this.Every30Seconds();
            Task loop20 = this.Every20Seconds();
            Taks loop10 = this.Every10Seconds();
            
            await Task.WhenAll( loop30, loop20, loop10 );
            return 0;
        }
        public static async Task Every30Seconds()
        {
            while( true )
            {
                Console.WriteLine("Ping!");
                await Task.Delay( 30 * 1000 );
            }
        }
        public static async Task Every20Seconds()
        {
            while( true )
            {
                Console.WriteLine("Pong!");
                await Task.Delay( 20 * 1000 );
            }
        }
        public static async Task Every10Seconds()
        {
            while( true )
            {
                Console.WriteLine("Pang!");
                await Task.Delay( 10 * 1000 );
            }
        }
    }
