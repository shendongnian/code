    using System.Collections.ObjectModel;
    <ListView Name="allCardsView" Source="{Binding}">
        <ListView.ItemTemplate>
            <DataTemplate DataType="{x:Type yourXmlns:Card}">
                //Your template here
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
    <ListView Name="selectedCardsView" Source="{Binding}">
        <ListView.ItemTemplate>
            <DataTemplate DataType="{x:Type yourXmlns:Card}">
                //Your template here
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
    ObservableCollection<Card> allCards = new ObservableCollection<Card>();
    ObservableCollection<Card> selectedCards = new ObservableCollection<Card>();
    allCardsView.DataContext = allCards;
    selectedCardsView.DataContext = selectedCards;
    public void ButtonClickHandler(object sender, EventArgs e) 
    {
        if (allCardsView.SelectedItem != null &&
            !selectedCards.Contains(allCardsView.SelectedItem)) 
        {
            selectedCards.Add(allCardsView.SelectedItem);
        }
    }
