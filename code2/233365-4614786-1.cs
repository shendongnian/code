    try
    {
        throw new OutOfMemoryException();
    }
    catch(Exception ex)
    {
    	"B".Dump();
    }
    catch(OutOfMemoryException ex)
    {
    	"A".Dump();
    }
