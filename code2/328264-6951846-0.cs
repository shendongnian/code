    void Main()
    {
    	var moves = new Dictionary<string, Move>()
    	{
    		{ "r", new Move(1, "Reloaded") },
    		{ "s", new Move(0, "Shielded") },
    		{ "f", new Move(-1, "Fired") },
    	};
    	
    	var messages = new Dictionary<string, string>()
    	{
    		{ "Shielded-Fired", "Nice shield, no one has died yet" },
    		{ "Fired-Fired", "You both died!  Good game!" },
    		{ "Reloaded-Fired", "No shield!?  You died!  Good game!" },
    		{ "Shielded-Shielded", "Keep playing it safe." },
    		{ "Fired-Shielded", "Genius is too good, no one has died yet" },
    		{ "Reloaded-Shielded", "No-one fired" },
    		{ "Shielded-Reloaded", "No-one fired" },
    		{ "Fired-Reloaded", "Genius let his guard down!  Good game!" },
    		{ "Reloaded-Reloaded", "No-one fired" },
    	};
    	
    	var isDone = new Dictionary<string, bool>()
    	{
    		{ "Shielded-Fired", false },
    		{ "Fired-Fired", true },
    		{ "Reloaded-Fired", true },
    		{ "Shielded-Shielded", false },
    		{ "Fired-Shielded", false },
    		{ "Reloaded-Shielded", false },
    		{ "Shielded-Reloaded", false },
    		{ "Fired-Reloaded", true },
    		{ "Reloaded-Reloaded", false },
    	};
    	
    	var rnd = new Random();
    	var choices = new [] { "r", "s", "f", };
    	
    	var human = new Player("You", () => Console.ReadLine(), m => Console.WriteLine(m));
    	var genius = new Player("Genius", () => choices[rnd.Next(0, 3)], m => { });
    	
    	var allMoves = GetPlayerMoves(moves, human).Zip(GetPlayerMoves(moves, genius), (h, g) =>
    	{
    		human.Play(h);
    		genius.Play(g);
    		var hg = String.Format("{0}-{1}", h.Name, g.Name);
    		Console.WriteLine(messages[hg]);
    		return isDone[hg];
    	});
    	
    	foreach (var done in allMoves)
    		if (done)
    			break;
    }
    
    private static IEnumerable<Move> GetPlayerMoves(Dictionary<string, Move> moves, Player player)
    {
    	while (true)
    	{
    		player.WriteMessage("\nEnter your move: ");
    		var choice = player.GetChoice();
    		if (moves.ContainsKey(choice))
    		{
    			var move = moves[choice];
    			if (move.Play(player.Ammo) < 0)
    			{
    				player.WriteMessage("\nYou don't have enough ammo, try again.\n");
    			}
    			else
    			{
    				yield return move;
    			}
    		}
    		else
    		{
    			player.WriteMessage("\nInvalid move, try again.\n");
    		}
    	}
    }
    
    public class Player
    {
    	public Player(string name, Func<string> getChoice, Action<string> writeMessage)
    	{
    		this.Name = name;
    		this.Ammo = 1;
    		_getChoice = getChoice;
    		_writeMessage = writeMessage;
    	}
    	
    	private readonly Func<string> _getChoice;
    	private readonly Action<string> _writeMessage;
    	
    	public string GetChoice()
    	{
    		return _getChoice();
    	}
    	
    	public void WriteMessage(string message)
    	{
    		_writeMessage(message);
    	}
    	
    	public string Name { get; private set; }
    	public int Ammo { get; private set; }
    	
    	public void Play(Move move)
    	{
    		this.Ammo = move.Play(this.Ammo);
    		Console.Write(String.Format("{0} {1} (ammo is {2}.)\n", this.Name, move.Name.ToLowerInvariant(), this.Ammo));
    	}
    }
    
    public class Move
    {
    	public Move(int ammoChange, string name)
    	{
    		this.AmmoChange = ammoChange;
    		this.Name = name;
    	}
    
    	public string Name { get; private set; }
    	
    	private int AmmoChange { get; set; }
    	
    	public int Play(int ammo)
    	{
    		return ammo + AmmoChange;
    	}
    }
