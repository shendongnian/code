    ~MyClass()
    {  
         Dispose( false );
         Console.WriteLine( "Argh, release me! I want better co-workers!" );
    }
    public Dispose()
    {  
         Dispose( true );
         GC.SuppressFinalization( this );
    }
    public Dispose( bool invokedByDeveloper )
    {  
         if( invokedByDeveloper )
             // free managed resources
         
         // free unmanaged resources
    }
