using System.ComponentModel;
public class Status_Update : INotifyPropertyChanged 
{
     //private property that stores value
     private string status;
     
     //public property the gets & sets value
     public string Status
     {
           get {return status;}
           set
           { 
               if(status != value)
               {
                   status = value; 
                   NotifyPropertyChanged("Status");
               } 
           }
     }
      
     //Logic to notify that property values have changed.
     public event PropertyChangedEventHandler PropertyChanged;
     public void NotifyPropertyChanged(string propName)
     {
         if (PropertyChanged != null)
         {
             PropertyChanged(this, new PropertyChangedEventArgs(propName));
         }
     }
     
}
Now lets move to your Control or Window's code behind constructor.
//Create a Status_Update object in your control.
public Status_Update My_Status {get;set;}
public My_Control_or_Window()
{
       //Initialize the Status_Update object
       MyStatus = new Status_Update(){Status=""};
       InitializeComponent();
      
       //Set the controls DataContext to itself in the constructor
       DataContext=this;
}
Now in your frontend's XAML you simply bind to your control's `MyStatus.Status` property and it's ready for live updates from any calling thread.
<Label Content={Binding MyStatus.Status, UpdateSourceTrigger=PropertyChanged}/>
To update simply set the value of `MyStatus.Status` from your BackgroundWorker.
private void BackgroundWorkder_DoWork(object sender, DoWorkEventArgs e)
{
     MyStatus.Status = "Updating the first item";
     Some_Task();
     MyStatus.Status = "Updating the next item";
     Some_Task();
}
I want to note that this example isn't the best example of MVVM, nor is it the best code structure for what you are trying to do, but it should help give you a better understanding of how binding works in WPF and how you can update things like a status label much easier with it. It takes a little more work on the front end, but saves so much time on the back end.     
Best of luck.
