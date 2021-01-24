    <ResourceDictionary ...>
        <DataTemplate DataType="{x:Type local:MyNewClass}"> ... 
        </DataTemplate> 
    </ResourceDictionary>
 - Import the Ressource from the dll in the main applications code behind
    ResourceDictionary dictionary = new ResourceDictionary();
    dictionary.Source = new Uri("/AssemblynameWithoutDLL;component/StyleDictionary.xaml", UriKind.RelativeOrAbsolute);
    Application.Current.Resources.MergedDictionaries.Add(dictionary);
After that, it is rendered correctly in the listbox.
Now I can dynamically load assemblies(e.g. from a plugin directory) and create some objects which are displayed as intended.
The assemblies' classes need to implement my interface to be identified and there must be "StyleDictionary.xaml" to be read.
