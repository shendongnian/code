    public IEnumerable<string> YourFunction(...)
    {
        //Your code
    }
    
    //later:
        //...
        try{
            foreach( string s in YourFunction(file) )
            {
                //Do Work
            }
        }
        catch(Exception e){
            throw ExceptionMapper.Map(e, file.FullName);
        }
