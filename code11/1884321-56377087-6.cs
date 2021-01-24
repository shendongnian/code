    <ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
                 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                 xmlns:converters="clr-namespace:ColorChangeDemo.Converters"
                 x:Class="ColorChangeDemo.Views.DeselectPage">
        <ContentPage.Resources>
            <ResourceDictionary>
                <converters:BoolToColorConverter x:Key="boolToColorConverter" TrueColor="Green" FalseColor="Gray" />
            </ResourceDictionary>
        </ContentPage.Resources>
        <ContentPage.Content>
            <ListView x:Name="ListView"  ItemsSource="{Binding SelectableItemGroups}" GroupShortNameBinding="{Binding Key}" GroupDisplayBinding="{Binding Key}" IsGroupingEnabled="True">
                <ListView.GroupHeaderTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Label Text="{Binding Key}" />
                        </ViewCell>
                    </DataTemplate>
                </ListView.GroupHeaderTemplate>
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Button 
                                x:Name="Button"
                                Text="{Binding Id}" 
                                BackgroundColor="{Binding Selected, Converter={StaticResource boolToColorConverter}}"
                                Command="{Binding Source={x:Reference ListView}, Path=BindingContext.ItemTappedCommand}"
                                CommandParameter="{Binding .}"/>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </ContentPage.Content>
    </ContentPage>
