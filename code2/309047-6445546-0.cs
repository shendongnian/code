    public class BudgetLineItem : INotifyPropertyChanged
    {
       public string Name { get; set; }
       public decimal Cost { get; set; }
    }
    public class BudgetGroup : INotifyPropertyChanged
    {
       public string GroupName { get; set; }
       public ObservableCollection<BudgetLineItem> LineItems { get; set; }
    }
    public class BudgetViewModel : INotifyPropertyChanged
    {
       public ObservableCollection<BudgetGroup> BudgetGroups { get; set; }
    }
