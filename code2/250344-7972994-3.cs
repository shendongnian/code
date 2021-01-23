    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Assets/Styles.xaml"/>
                <ResourceDictionary Source="Skins/MainSkin.xaml" />                
            </ResourceDictionary.MergedDictionaries>
            <!--Global View Model Locator-->
            <vm:ViewModelLocator x:Key="Locator" d:IsDataSource="True" />
        </ResourceDictionary>        
    </Application.Resources>
