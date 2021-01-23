	class HugeClass
	{
		[Obsolete("Use ModuleX.DoModuleXJob() instead", false)]
		public void DoModuleXJob() {
			ModuleX mod = new ModuleX();
			mod.DoModuleXJob();
		}
	}
	class ModuleX
	{
		public void DoModuleXJob() {
		}
	}
