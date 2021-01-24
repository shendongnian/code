    <!--Declare the namespace at the top of the XAML-->
    xmlns:c="clr-namespace:Demo.Helper"
    <!--Register your Converter in the Resources-->
    <ContentPage.Resources>
        <ResourceDictionary>
            <c:TextToBoolConverter x:Key="textToSpeechConverter" />
        </ResourceDictionary>
    </ContentPage.Resources>
    <Entry x:Name="entry1" Text="{Binding ObjectViewModel.MyString}" />
    <Label Text="Valid!" IsVisible="{Binding Text, Source={x:Reference entry1}, Converter={StaticResource textToSpeechConverter}}"/>
