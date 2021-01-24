private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            SINSessionViewModel vm = null;
            vm = new SINSessionViewModel(dialogProvider);
            vm.CreateSession.Execute(SessionPurpose.Clinic);
            ViewModel = vm;
            ViewModel_LifecycleChanged(vm, EventArgs.Empty);
        }
private Dictionary<SessionLifecycle, Func<SINSessionViewModel, Control>> LifecycleViews = new Dictionary<SessionLifecycle, Func<SINSessionViewModel, Control>>()
        {
            { SessionLifecycle.Login, vm => {
                Control c = new LoginView();
                c.DataContext = vm;
                return c;
            } },
            { SessionLifecycle.Setup, vm => {
                Control c = new ClinicSINSessionView();
                c.DataContext = vm;
                return c;
            } },
            { SessionLifecycle.Testing, vm => new SINListView() { DataContext = vm.CurrentListViewModel } },
            {
                SessionLifecycle.Finished, vm => {
                    vm.ExportAsCsvAsync();
                    Logger.Singleton.SessionComplete();
                    return new SessionResultView() { DataContext = vm };
                }
            }
        };
and in my loginView have the following command:
.
.
.
<Grid>
        <StackPanel Margin="10">
            <Label>Username:</Label>
            <TextBox Height="25" Margin="0,0,0,0" Text="{Binding Username}" Name="txtUsername"/>
            <Label>Password:</Label>
            <PasswordBox Height="25" Margin="0,-20,0,0" Name="txtPassword"
                         ff:PasswordBoxAssistant.BindPassword="true"  ff:PasswordBoxAssistant.BoundPassword="{Binding Path=Password, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
            <Button DockPanel.Dock="Bottom" VerticalAlignment="Bottom" Margin="10" TabIndex="99" Height="25" Content="Login"
                Command="{Binding Path=LoginCommand}">
            </Button>
        </StackPanel>
    </Grid>
.
.
public LoginCommandClass LoginCommand
        {
            get
            {
                //the validation (code is deleted)
                    async() =>
                    {
                        //login process  (code is deleted)
                        Lifecycle = SessionLifecycle.Setup;//this will raise an event 
                    } );
                return _login;
            }
        }
public event EventHandler LifecycleChanged;
public SessionLifecycle Lifecycle
        {
            get { return _lifecycle; }
            private set
            {
                _lifecycle = value;
                if (LifecycleChanged != null) { LifecycleChanged(this, EventArgs.Empty); }
            }
        }
and in the MainWindow:
void ViewModel_LifecycleChanged(object sender, EventArgs e)
        {
            var requestedView = LifecycleViews[ViewModel.Lifecycle](ViewModel);
            MainView.Content = requestedView;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsInSession)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CanRecoverSession)));
        }
which reads the dictionary containing the views and load them
