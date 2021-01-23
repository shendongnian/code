    Database db = DBSingleton.GetInstance();
    using (DbCommand command = db.GetStoredProcCommand(spName))
    {
        //The three Add In Parameters... & then the Add out Parameter as below
        db.AddOutParameter(command, "myFlag", System.Data.DbType.Int32, LocVariable );
        using ( IDataReader reader = db.ExecuteReader(command))
        {
             //Loop through cursor values & store them in code behind class-obj(s)
             //The reader must be closed before trying to get the "OUT parameter"
             reader.Close();
    
             //Only after reader is closed will any parameter result be assigned
             //So now we can get the parameter value.
             //if reader was not closed then OUT parameter value will remain null
             //Getting the parameter must be done within this code block
             //I could not get it to work outside this code block
             <Type> result = (typecast)command.Parameters["OUT_parameter_name"];
        }
    }
    //I USED THIS APPROACH TO RETURN MULTIPLE PARAMETERS ALONG WITH THE CURSOR READ
