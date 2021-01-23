    public interface ICarPart{
        int SomeMethodFromInterface();
    }
	
	public interface ICarPartMetadata{
        string /*attention to this!!!*/ NameCarPart { get; } /* Only for read. */
    }
	
