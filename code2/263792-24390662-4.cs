    public static bool Write( string filename )
    {
        using( var fs = new System.IO.FileStream( filename,
            System.IO.FileMode.Create,
            System.IO.FileAccess.Write,
            System.IO.FileShare.None ) )
        {
            bool got_handle;
            bool result;
            // The CER is here to ensure that reference counting on fs.SafeFileHandle is never
            // corrupted. 
            System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                fs.SafeFileHandle.DangerousAddRef( ref got_handle );
            }
            catch( Exception e )
            {
                if( got_handle )
                {
                    fs.SafeFileHandle.DangerousRelease();
                }
                got_handle = false;
                throw;
            }
            finally
            {
                if( got_handle )
                {
                    result = NativeMethods.Foo( fs.SafeFileHandle.DangerousGetHandle() );
                    fs.SafeFileHandle.DangerousRelease();
                }
            }
            return result;
        }
    }
