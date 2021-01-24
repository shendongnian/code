        static class Extensions
        {
            public static TOut N<TIn,TOut>( this TIn value, Func<TIn,TOut> whenNotNull )
                where TIn : class
                where TOut : class
            {
                if( value == null ) return null;
                return whenNotNull( value );
            }
        }
    Used like so:
        txtbox1.Text = dtDetails.Rows[0].Field<String>("columnName").N( v => v.Trim() ) ?? "--";
