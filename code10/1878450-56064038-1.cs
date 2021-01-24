    				public partial class MainWindow : Window
					{
						List<TestEnableButton> objtestEnableButton = new List<TestEnableButton>();        
						public MainWindow()
						{
							InitializeComponent();
							this.DataContext = this;
						}
						private void MyGrid_Loaded(object sender, RoutedEventArgs e)
						{
							objtestEnableButton.Add(new TestEnableButton("A1", true, false));
							objtestEnableButton.Add(new TestEnableButton("A2", true, false));
							objtestEnableButton.Add(new TestEnableButton("A3", true, false));
							objtestEnableButton.Add(new TestEnableButton("A4", true, false));
							MyGrid.ItemsSource = objtestEnableButton;
						}
						bool butFlg = false;
						private void Button_Click(object sender, RoutedEventArgs e)
						{
							var getButtonName = (sender as Button).Name;
							var currentItem = MyGrid.CurrentItem as TestEnableButton;
							foreach(var items in objtestEnableButton)
							{
								if (items.Name == currentItem.Name)
								{
									if (getButtonName == "Play")
									{
										MessageBox.Show("Let's enjoy music...!)");
										butFlg = false;
									}
									else if (getButtonName == "Pause")
									{
										MessageBox.Show("Pause the music for few minutes...!)"); butFlg = false;
									}
									else if (getButtonName == "Stop")
									{
										MessageBox.Show("Stop the music...!)"); butFlg = false;
									}
									else if (getButtonName == "Finish")
									{
										MessageBox.Show("End...!)");                        
										items.IsCheckFinish = true;
										butFlg = true;
									}
								}
								else
								{
									items.IsEnableButton = false;
								}
							}
							if (butFlg)
							{
								var itemsCollection = objtestEnableButton.RemoveAll(x => x.IsCheckFinish == true);
								objtestEnableButton.ForEach(x => x.IsEnableButton = true);
								MyGrid.ItemsSource = null;
								MyGrid.ItemsSource = objtestEnableButton;
							}            
						}
					}
					public class TestEnableButton : INotifyPropertyChanged
					{
						private string _name;
						public string Name
						{
							get { return _name; }
							set
							{
								_name = value;
								OnPropertyChanged("Name");
							}
						}
						private bool _IsEnableButton;
						public bool IsEnableButton
						{
							get { return _IsEnableButton; }
							set
							{
								_IsEnableButton = value;
								OnPropertyChanged("IsEnableButton");
							}
						}
						private bool _IsCheckFinish;
						public bool IsCheckFinish
						{
							get { return _IsCheckFinish; }
							set
							{
								_IsCheckFinish = value;
								OnPropertyChanged("IsCheckFinish");
							}
						}
						public TestEnableButton(string name, bool isB, bool isCheck)
						{
							Name = name;
							IsEnableButton = isB;
							IsCheckFinish = isCheck;
						}
						public event PropertyChangedEventHandler PropertyChanged;
						public void OnPropertyChanged(string propertyName)
						{
							if (PropertyChanged != null)
							{
								PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
							}
						}
					}
