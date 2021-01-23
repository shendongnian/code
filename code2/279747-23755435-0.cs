    ICertView2 certView = null;
    IEnumCERTVIEWROW row = null;
    try
    {
    	certView = new CCertView();
    	certView.OpenConnection( _strCAConfig );
    	certView.SetResultColumnCount( 1 );
    	certView.SetResultColumn( certView.GetColumnIndex( 0, "RequestID" ) );
    	row = certView.OpenView();
    	row.Next();
    	return row.GetMaxIndex();
    }
    finally
    {
    	Marshal.ReleaseComObject( row );
    	Marshal.ReleaseComObject( certView );
    }
