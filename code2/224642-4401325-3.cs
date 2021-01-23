    using System;
    using System.Collections.Generic;
    using System.Web.Services;
    namespace Tests {
    	public partial class Test : System.Web.UI.Page {
    		[WebMethod]
    		static public IDictionary<string,string> test( int length ) {
    			if ( 0 > length ) {
    				throw  new ArgumentException( "Length cannot be less than zero", "length" );
    			}
    			var  result = new Dictionary<string,string>( length );
    			for ( int  i = 0;  i < length;  i ++ ) {
    				result.Add(i.ToString(), Char.ConvertFromUtf32(65 + i) +"|"+ Char.ConvertFromUtf32(97 + i));
    			}
    			return  result;
    		} // IDictionary<string,string> test( int )
    	}
    }
