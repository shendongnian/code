    string sourcepath; //containts the source file path, set by other code
    string temppath; //containts teh path of the tempfile. Should be in the same folder, and thus same partiion
    
    //Open both Streams, can use a single using for this
    //The supression of any Buffering on the output should  be optional and will be detrimental to performance
    using(var sourceStream = File.OpenRead(sourcepath), 
      outStream = File.Create(temppath, 0, FileOptions.WriteThrough )){
    	
    	string line = "";
    	
    	//itterte over the input
    	while((line = streamReader.ReadLine()) != null){
    		//do processing on line here
    		
    		outStream.Write(line);
    	}
    }
