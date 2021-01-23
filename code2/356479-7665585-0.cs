    void Main()
    {
    	var factory = new PieceFactory<Rook, int>(20);
    	factory.GetPiece().Dump();
    }
    
    abstract class Piece<TValue>
    {
    	public TValue Value { get; set; }
    }
    
    class Rook : Piece<int>
    {
    	public int Capture()
    	{
            // Do something...
    		return base.Value;
    	}
    }
    
    class Pawn : Piece<string>
    {
    	public string EnPassant()
    	{
            // Do something...
    		return base.Value;
    	}
    }
    
    class PieceFactory<TKey, TValue> where TKey : Piece<TValue>, new()
    {
    	private readonly TKey piece;
    	
    	public PieceFactory(TValue value)
    	{
    		this.piece = new TKey();
    		this.piece.Value = value;
    	}
    	
    	public TKey GetPiece()
    	{
    		return this.piece;
    	}
    }
