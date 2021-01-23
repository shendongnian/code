    private IList<IPosition> PositionsLoad(SqlConnection connection, PositionsRequest request)
    {
    
    	SqlCommand cmd = new SqlCommand();
    	cmd.Connection = connection;
    	cmd.CommandText = "select * from mytable WHERE x ";
    	cmd.CommandType = CommandType.Text;
    
    	//Get the reader
    	SqlDataReader reader = cmd.ExecuteReader;
    	IList<IPosition> ret = new List<IPosition>();
    
    	if (reader.HasRows()) {
    		//Create our converter to convert DataReader into a business object/s
    		DataReaderToPosition readerConvert = new DataReaderToPosition();
    		//loop rows
    		while (reader.Read) {
    			IPosition pos = readerConvert.DataReaderToBusinessObject(reader);
    			ret.Add(pos);
    		}
    	}
    
    	reader.Close();
    	return ret;
    
    }
