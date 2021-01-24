c#
   public partial class MyForm : Page, INotifyPropertyChanged
   {
      private int _percentage_completed = 0;
      public int PercentageOfTasksCompleted
      {
         get
         {
            return _percentage_completed;
         }
         set
         {
            _percentage_completed = value;
            if (PropertyChanged != null)
            {
               PropertyChanged(this, new PropertyChangedEventArgs("PercentageOfTasksCompleted"));
            }
         }
      }
to set the PercentageOfTasksCompleted value:
c#
while (externalAPI.NumberOfTasksCompleted < externalAPI.TotalNumberOfTasks)
{
   PercentageOfTasksCompleted = 100 * externalAPI.NumberOfTasksCompleted / externalAPI.TotalNumberOfTasks;
   Thread.Sleep(100);
}
With this solution the progress bar value is updated at the specified intervals, but I wonder if there is a more "seamless" approach.
