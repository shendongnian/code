	public interface ISettingsUpgrader
	{
		void UpgradeSettings();
	}
	public abstract class SettingsUpgrader : SettingsUpgrader
	{
		protected int version;
		public virtual void UpgradeSettings()
		{
			// load settings and read version info
			version = settingsVersion;
		}
	}
	public class SettingsUpgraderV2 : SettingsUpgrader
	{
		public override void UpgradeSettings()
		{
			base.UpgradeSettings();
			if(version > 1) return;
			// do the v1 -> v2 upgrade
		}
	}
	public class SettingsUpgraderV3 : SettingsUpgraderV2
	{
		public override void UpgradeSettings()
		{
			base.UpgradeSettings();
			if(version > 2) return;
			// do the v2 -> v3 upgrade
		}
	}
