    <ContentPage.Resources>
        <ResourceDictionary>
            <CollectionViewDemos:StringToColorConverter x:Key="StringToColorConverter"/>
        </ResourceDictionary>
    </ContentPage.Resources>
    Frame BackgroundColor="{Binding MyColor, Converter={StaticResource StringToColorConverter}}"
