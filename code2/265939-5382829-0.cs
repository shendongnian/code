    public class NameList : ObservableCollection<PersonName>
    {
        public NameList() : base()
        {
            Add(new PersonName("A", "E"));
            Add(new PersonName("B", "F"));
            Add(new PersonName("C", "G"));
            Add(new PersonName("D", "H"));
        }
      }
    
      public class PersonName
      {
          private string firstName;
          private string lastName;
    
          public PersonName(string first, string last)
          {
              this.firstName = first;
              this.lastName = last;
          }
    
          public string FirstName
          {
              get { return firstName; }
              set { firstName = value; }
          }
    
          public string LastName
          {
              get { return lastName; }
              set { lastName = value; }
          }
      }
    
    Now in XAML. Go to resource tag
    
    <Window
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      
    
        xmlns:c="clr-namespace:SDKSample" // xmnls:c = will cgive you option to choose the class. Here you can choose c,d ,e x whatever but be sure it should be used earlier
    
      x:Class="Sample.Window1"
      Width="400"
      Height="280"
      Title="MultiBinding Sample">
    	
      <Window.Resources>
        <c:NameList x:Key="NameListData"/>
    </Window.Resources>
    
    
    <ListBox Width="200"
             ItemsSource="{Binding Source={StaticResource NameListData}}"  // Name list data is declared in resource
             ItemTemplate="{StaticResource NameItemTemplate}"
             IsSynchronizedWithCurrentItem="True"/>
