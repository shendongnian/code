     private float total;
     public float Total
    {
        get { return TicketsEnVente.Sum(x =>x.Prix); }
        set
        {
            total = value;
            OnPropertyChanged("Total");
        }
    }
Note that you probably want your button to clear your data collection and then trigger OnPropertyChanged(Total). 
public void ResetData()
{
    Collection.Clear();
    OnPropertyChanged(Total);
}
