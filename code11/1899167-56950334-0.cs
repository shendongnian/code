cs
public BindableCollection<ICanCalculate> Work { get; set; } = App.Config.Work;
public void Update()
{
    Work.CalculateQuotations(_tableViewModel.WoodTotal);
    Work = new BindableCollection<ICanCalculate>(Work);
}
Last time `CalculateQuotations` was just a method that operates on the same object, therefore the property isn't set again, only the properties inside is changed. i.e. the property is still the same object.
Even if I call `OnPropertyChanged(nameof(Work))` explicitly it didn't fix it, but this puts a new object and it updates everything.
