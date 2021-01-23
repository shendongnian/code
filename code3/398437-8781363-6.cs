    public class Form1 : Form
    {
    	private Game game;
    	private Label[,] pole;
    
    	public Form1()
    	{
    		game = new Game();
    		game.GameChanged += new EventHandler(Game_GameChanged);
    
    		pole = new Label[Game.Width, Game.Height];
    
    		// Intialize pole.
    		// ...
    	}
    
    	void Game_GameChanged(object sender, EventArgs e)
    	{
    		for (int x = 0; x < Game.Width; x++) {
    			for (int y = 0; y < Game.Height; y++) {
    				Square square = game.Board[x, y];
    				Label label = pole[x,y];
    				switch (square.State) {
    					case State.Empty:
    						label.BackColor = Color.Blue;
    						label.Text = "Z";
    						break;
    					case State.Neutral:
    						label.BackColor = Color.Blue;
    						label.Text = square.Number.ToString();
   						    break;
    					case State.Good:
    						label.BackColor = Color.Green;
    						label.Text = square.Number.ToString();
    						break;
    					case State.Bad:
    						label.BackColor = Color.Red;
    						label.Text = square.Number.ToString();
    						break;
    					default:
    						break;
    				}
    			}
    		}
    
    		// Place lblCovece according to game.CurrentX and game.CurrentY
    		// ...
    	}
    
    	private void bReset_Click(object sender, EventArgs e)
    	{
    		game.Reset();
    	}
    
    	private void bLeft_Click(object sender, EventArgs e)
    	{
    		game.MoveLeft();
    	}
    
    	private void bRight_Click(object sender, EventArgs e)
    	{
    		game.MoveRight();
    	}
    }
