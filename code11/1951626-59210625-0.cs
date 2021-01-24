public class TabControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public SaveCommand SaveCommand { get; set; }
        public TabOneUserControlViewModel TabOneUserControl { get; set; }
        public TabTwoUserControlViewModel TabTwoUserControl { get; set; }
        public TabControlViewModel()
        {
            TabOneUserControl = new TabOneUserControlViewModel();
            TabTwoUserControl = new TabTwoUserControlViewModel();
            SaveCommand = new SaveCommand(this);
        }
        public void SaveInformation()
        {
            using (TestDbEntities test = new TestDbEntities())
            {
                test.FNs.Add(new FN
                {
                    FirstName = TabOneUserControl.FirstName
                });
                test.LNs.Add(new LN
                {
                    LastName = TabTwoUserControl.LastName
                });
                try
                {
                    test.SaveChanges();
                    Debug.Print("SAVED CHANGES!");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation(
                                  "Class: {0}, Property: {1}, Error: {2}",
                                  validationErrors.Entry.Entity.GetType().FullName,
                                  validationError.PropertyName,
                                  validationError.ErrorMessage);
                        }
                    }
                }
            }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
**TabOneUserControl**
Removed the static resource from the grid and replaced it with a regular binding and then changed the binding in the Text element, this was the same thing I did in the second user control so I will negate posting the second UserControl:
<Grid DataContext="{Binding TabOneUserControl}">
        <StackPanel VerticalAlignment="Center">
            <Label Content="First Name"
                   HorizontalAlignment="Center"/>
            <TextBox Width="250"
                     Height="50"
                     Text="{Binding FirstName, UpdateSourceTrigger=PropertyChanged}"/>
        </StackPanel>
    </Grid>
