    string sourcepath; //containts the source file path, set by other code
    string temppath; //containts teh path of the tempfile. Should be in the same folder, and thus same partiion
    
    //Open both Streams, can use a single using for this
    using((var sourceStream = File.OpenRead(sourcepath), 
      outStream = File.OpenWrite(temppath)){
    	
    	//itterte over the input
    	while((line = streamReader.ReadLine()) != null){
    		//do processing on line here
    		
    		outStream.Write(line);
    	}
    	
    }
    
    //replace the files. Pretty sure it will just overwrite without asking
    File.Move(temppath, sourcepath);
