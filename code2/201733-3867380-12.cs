	public interface IGame
	{
		IPlayer NextPlayer { get; }
		bool NextPlayerCanPlay { get; }
	}
	internal interface ITestableGame
	{
		IPlayer NextPlayer { get; set; }
		bool NextPlayerCanPlay { get; set; }
	}
	public class Game : IGame, ITestableGame
	{
		public IPlayer NextPlayer { get; set; }
		public bool NextPlayerCanPlay { get; set; }
	}
