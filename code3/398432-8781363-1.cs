    public enum State
    {
    	Neutral, // Blue 
    	Good,    // Green 
    	Bad      // Red
    }
    
    public class Square
    {
    	public int Number { get; set; }
    	public State State { get; set; }
    }
    
    public class Game
    {
    	public const int Width = 7, Height = 6;
    
    	public Game()
    	{
    		Board = new Square[Width, Height];
    	}
    
    	public event EventHandler GameChanged;
    
    	public Square[,] Board { get; private set; }
    
    	public int CurrentX { get; private set; }
    	public int CurrentY { get; private set; }
    
    	public void Reset()
    	{
    		for (int x = 0; x < Width; x++) {
    			for (int y = 0; y < Height; y++) {
    				Board[x, y].State = State.Neutral;  // Always displayed in blue as "Z"
    			}
    		}
    		OnGameChanged();
    	}
    
    	public void MoveLeft()
    	{
    		if (CurrentX > 0) {
    			CurrentX--;
    			OnGameChanged();
    		}
    	}
    
    	public void MoveRight()
    	{
    		if (CurrentX < Width - 1) {
    			CurrentX++;
    			OnGameChanged();
    		}
    	}
    
    	// and so on
    
    	private void OnGameChanged()
    	{
    		EventHandler eh = GameChanged;
    		if (eh != null) {
    			eh(this, EventArgs.Empty);
    		}
    	}
    }
