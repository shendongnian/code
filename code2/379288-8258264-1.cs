	public class ComputerManager
	{
		public IEnumerable<string> GetAllLogs(IEnumerable<IComputer> computers)
		{
			return computers.AsParallel().SelectMany(c => c.GetLogs()).ToArray();
		}
	}
