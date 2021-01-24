public class Tile
{
	public string ModuleName { get; set; }
	//public NamedViewModelBase ModuleViewModel { get; set; }
	public Action ThisCommand { get; set; }
}
And here's how I tried to implement it as a List:
List<Tile> tiles = new List<Tile>()
{
	new Tile()
	{
		ModuleName = "Program",
		ThisCommand = () => 
		{
			if (ServiceLocator.IsLocationProviderSet)
			{
				SimpleIoc ioc = ServiceLocator.Current as SimpleIoc;
				ioc.GetInstanceWithoutCaching<ProgramViewModel>(Guid.NewGuid().ToString());
			}
		}
	},
	new Tile()
	{
		ModuleName = "Organization",
		ThisCommand = () =>
		{
			if (ServiceLocator.IsLocationProviderSet)
			{
				SimpleIoc ioc = ServiceLocator.Current as SimpleIoc;
				ioc.GetInstanceWithoutCaching<OrganizationViewModel>(Guid.NewGuid().ToString());
			}
		}
	}
};
Am I on the right track? Should I define ```tiles``` as a Dictionary instead?
