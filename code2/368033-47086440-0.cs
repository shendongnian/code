            const int MMF_MAX_SIZE = 209_715_200;
            var buffer = new byte[ MMF_VIEW_SIZE ];
            using( var mmf = MemoryMappedFile.OpenExisting( "mmf1" ) )
            using( var view = mmf.CreateViewStream( 0, buffer.Length, MemoryMappedFileAccess.ReadWrite ) )  
            {
                if( view.CanRead )
                {
                    Console.WriteLine( "Begin read" );
                    sw.Start( );
                    view.Read( buffer, 0, MMF_MAX_SIZE );
                    sw.Stop( );
                    Console.WriteLine( $"Read done - {sw.ElapsedMilliseconds}ms" );
                }
            }
