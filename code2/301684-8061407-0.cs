    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Threading;
    namespace TaskToy
    {
        class Program
        {
            static void Main( string[] args )
            {
                List<Task> lTasks = new List<Task>();
                int lWidth = 0;
                for ( int i = 0; i < 5000; i ++ )
                {
                    lTasks.Add( new Task( (o) => {
                        Console.WriteLine( "B " + Interlocked.Increment( ref lWidth ) + " tid " + Thread.CurrentThread.ManagedThreadId );
                        Thread.Sleep( 60000 );
                        Console.WriteLine( "E " + Interlocked.Decrement( ref lWidth ) + " tid " + Thread.CurrentThread.ManagedThreadId );
                    }, null, TaskCreationOptions.LongRunning ) );
                }
                Parallel.For( 0, lTasks.Count, ( i ) =>
                {
                    lTasks[i].Start();
                } );
                Task.WaitAll( lTasks.ToArray() );
                Console.WriteLine( "DONE - press any key..." );
                Console.ReadKey( true );
            }
        }
    }
