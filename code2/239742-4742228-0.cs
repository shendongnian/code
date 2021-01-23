    class Whatever
    {
        public event EventHandler Foo;
    
        protected virtual void OnFoo( EventArgs e )
        {
            EventHandler del = Foo;
            if( del != null )
            {
                del( this, e);
            }
        }
    }
