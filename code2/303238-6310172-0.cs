	public interface ICanBeRecreated<T>
	{
		T Recreate();
	}
	public class CormantDock : ICanBeRecreated<CormantDock>
	{
		private RadDockSetting _settings;
		private void ApplySettings(RadDockSetting settings)
		{
			// apply settings		
		}
		public CormantDock Recreate()
		{
			var dock = new CormantDock;
			dock.ApplySettings(_settings);
		}
	}
