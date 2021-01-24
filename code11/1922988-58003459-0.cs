csharp
public OverviewViewModel(){
 MessagingCenter.Subscribe<IntakeOutflowViewModel, string>(this, "LabelChanged", (sender, label)=>{
   this.LabelValue = label; // use value of label from IntakeOutflowViewModel
})
}
And on IntakeOutflowViewModel
csharp
public ICommand ButtonCommand => new Command(()=>{
    MessagingCenter.Send<IntakeOutflowViewModel,string>(this, "LabelChanged", LabelValue);
})
public string LabelValue{...,...} // The value you bind on view
Hope it helps
