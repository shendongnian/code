 public View1ViewModel View1Vm { get { return new View1ViewModel(); } }
----------
MainViewViewModel.cs
-------------------
 private void ShowView1()
 {            
    CurrentViewModel = new ViewModelLocator().View1Vm;           
 }
----------
View1View.xaml
-------------------
<UserControl x:Class="SidebarApp.View1View"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:SidebarApp"
             mc:Ignorable="d"                  
             d:DesignHeight="450" d:DesignWidth="800">
    <Grid Background="LightPink">
        <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
            <TextBlock HorizontalAlignment="Center" Text="Welcome to View 1" FontSize="20"/>
            <TextBox HorizontalAlignment="Stretch" Text="{Binding Path=View1Text, Mode=TwoWay}"/>
            <CheckBox Content="Some boolean value" IsChecked="{Binding Path=CheckBoxChecked, Mode=TwoWay}"/>
        </StackPanel>
    </Grid>
</UserControl>
View1ViewModel.cs
-----------------
public class View1ViewModel : ViewModelBase
{
        private string _view1Text;
        private bool _checkBoxedChecked;
        public string View1Text
        {
            get
            {
                return _view1Text;
            }
            set
            {
                _view1Text = value;
                RaisePropertyChanged("View1Text");                
            }
        }
        public bool CheckBoxChecked
        {
            get
            {
                return _checkBoxedChecked;
            }
            set
            {
                _checkBoxedChecked = value;
                RaisePropertyChanged("CheckBoxChecked");
            }
        }
        public View1ViewModel()
        {
            View1Text = "Original text value";
        }
}
