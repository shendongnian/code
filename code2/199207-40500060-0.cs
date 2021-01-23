    //Of note: it's faster to read all the lines we are going to act on and 
                //then process them in parallel instead of reading and processing line by line.
                //Code source: http://cc.davelozinski.com/code/c-sharp-code/read-lines-in-batches-process-in-parallel
                while (blnFileHasMoreLines)
                {
                    batchStartTime = DateTime.Now;  //Reset the timer
    
                    //Read in all the lines up to the BatchCopy size or
                    //until there's no more lines in the file
                    while (intLineReadCounter < BatchSize && !tfp.EndOfData)
                    {
                        CurrentLines[intLineReadCounter] = tfp.ReadFields();
                        intLineReadCounter += 1;
                        BatchCount += 1;
                        RecordCount += 1;
                    }
    
                    batchEndTime = DateTime.Now;    //record the end time of the current batch
                    batchTimeSpan = batchEndTime - batchStartTime;  //get the timespan for stats
    
                    //Now process each line in parallel.
                    Parallel.For(0, intLineReadCounter, x =>
                    //for (int x=0; x < intLineReadCounter; x++)    //Or the slower single threaded version for debugging
                    {
                        List<object> values = null; //so each thread gets its own copy. 
     
                        if (tfp.TextFieldType == FieldType.Delimited)
                        {
                            if (CurrentLines[x].Length != CurrentRecords.Columns.Count)
                            {
                                //Do what you need to if the number of columns in the current line
                                //don't match the number of expected columns
                                return; //stop now and don't add this record to the current collection of valid records.
                            }
    
                            //Number of columns match so copy over the values into the datatable
                            //for later upload into a database
                            values = new List<object>(CurrentRecords.Columns.Count);
                            for (int i = 0; i < CurrentLines[x].Length; i++)
                                values.Add(CurrentLines[x][i].ToString());
    
                            //OR do your own custom processing here if not using a database.
                        }
                        else if (tfp.TextFieldType == FieldType.FixedWidth)
                        {
                            //Implement your own processing if the file columns are fixed width.
                        }
    
                        //Now lock the data table before saving the results so there's no thread bashing on the datatable
                        lock (oSyncLock)
                        {
                            CurrentRecords.LoadDataRow(values.ToArray(), true);
                        }
    
                        values.Clear();
    
                    }
                    ); //Parallel.For   
     
                    //If you're not using a database, you obviously won't need this next piece of code.
                    if (BatchCount >= BatchSize)
                    {   //Do the SQL bulk copy and save the info into the database
                        sbc.BatchSize = CurrentRecords.Rows.Count;
                        sbc.WriteToServer(CurrentRecords);
    
                        BatchCount = 0;         //Reset these values
                        CurrentRecords.Clear(); //  "
                    }
    
                    if (CurrentLines[intLineReadCounter] == null)
                        blnFileHasMoreLines = false;    //we're all done, so signal while loop to stop
    
                    intLineReadCounter = 0; //reset for next pass
                    Array.Clear(CurrentLines, 0, CurrentLines.Length);
    
                } //while blnhasmorelines
