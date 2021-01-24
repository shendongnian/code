c#
namespace WpfApp.Models
{
    public interface IAddress
    {
        string Street { get; }
    }
    public class Address : IAddress
    {
        public Address(string street)
        {
            Street = street;
        }
        public string Street { get; }
    }
    
	public class Contact
    {
        public Contact(string name, IAddress mainAddress, IAddress[] addresses)
        {
            Name = name;
            MainAddress = mainAddress;
            Addresses = addresses;
        }
        public string Name { get; }
        public IAddress MainAddress { get; }
        public IAddress[] Addresses { get; }
    }
}
Next, the additional `ItemsContext` abstraction and the `ReceiptViewModel`.
c#
namespace WpfApp.ViewModels
{
    public class ItemsContext : ViewModelBase
    {
        public ItemsContext(Contact contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
			// Compose the collection however you like
            Items = new ObservableCollection<IAddress>(contact.Addresses.Prepend(contact.MainAddress));
            DisplayMemberPath = nameof(IAddress.Street);
            SelectedItem = Items.First();
        }
        public ObservableCollection<IAddress> Items { get; }
        public string DisplayMemberPath { get; }
        private IAddress selectedItem;
        public IAddress SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
                // Prevent XAML designer from tearing down VS
                if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                {
                    MessageBox.Show($"Billing address changed to {selectedItem.Street}");
                }
            }
        }
    }
    public class ReceiptViewModel : ViewModelBase
    {
        public ReceiptViewModel()
        {
            Contacts = new ObservableCollection<Contact>(FetchContacts());
            SelectedContact = Contacts.First();
        }
        public ObservableCollection<Contact> Contacts { get; }
        private Contact selectedContact;
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                SelectedContext = new ItemsContext(value);
                OnPropertyChanged();
            }
        }
        private ItemsContext selectedContext;
        public ItemsContext SelectedContext
        {
            get { return selectedContext; }
            set
            {
                selectedContext = value;
                OnPropertyChanged();
            }
        }
        private static IEnumerable<Contact> FetchContacts() =>
            new List<Contact>
            {
                new Contact("Foo", new Address("FooMain"), new Address[] { new Address("FooA"), new Address("FooB") }),
                new Contact("Bar", new Address("BarMain"), new Address[] { new Address("BarA"), new Address("BarB") }),
                new Contact("Zoo", new Address("ZooMain"), new Address[] { new Address("ZooA"), new Address("ZooB") }),
            };
    }
    abstract public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } 
}
To apply the `ItemsContext` I chose to use an attached property as well, though you could opt to subclass `ComboBox` (or anything deriving from `Selector`) too.
c#
namespace WpfApp.Extensions
{
    public class Selector
    {
        public static ItemsContext GetContext(DependencyObject obj) => (ItemsContext)obj.GetValue(ContextProperty);
        public static void SetContext(DependencyObject obj, ItemsContext value) => obj.SetValue(ContextProperty, value);
        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.RegisterAttached("Context", typeof(ItemsContext), typeof(Selector), new PropertyMetadata(null, OnItemsContextChanged));
        private static void OnItemsContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = (System.Windows.Controls.Primitives.Selector)d;
            var ctx = (ItemsContext)e.NewValue;
            if (e.OldValue != null) // Clean up bindings from previous context, if any
            {
                BindingOperations.ClearBinding(selector, System.Windows.Controls.Primitives.Selector.SelectedItemProperty);
                BindingOperations.ClearBinding(selector, ItemsControl.ItemsSourceProperty);
                BindingOperations.ClearBinding(selector, ItemsControl.DisplayMemberPathProperty);
            }
            selector.SetBinding(System.Windows.Controls.Primitives.Selector.SelectedItemProperty, new Binding(nameof(ItemsContext.SelectedItem)) { Source = ctx, Mode = BindingMode.TwoWay });
            selector.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(nameof(ItemsContext.Items)) { Source = ctx });
            selector.SetBinding(ItemsControl.DisplayMemberPathProperty, new Binding(nameof(ItemsContext.DisplayMemberPath)) { Source = ctx });
        }
    }
}
Wrapping up with the view.
xaml
<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:vm="clr-namespace:WpfApp.ViewModels"
        xmlns:ext="clr-namespace:WpfApp.Extensions"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800" WindowStartupLocation="CenterScreen">
    <Window.DataContext>
        <vm:ReceiptViewModel/>
    </Window.DataContext>
    <Window.Resources>
        <Style TargetType="{x:Type ComboBox}">
            <Setter Property="Width" Value="150"/>
            <Setter Property="HorizontalAlignment" Value="Left"/>
            <Setter Property="Margin" Value="0,0,0,20"/>
        </Style>
    </Window.Resources>
    <Grid Margin="20">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="100" />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <TextBlock Grid.Row="0" Grid.Column="0" Text="Contact Name" />
        <ComboBox Grid.Row="0" Grid.Column="1" ItemsSource="{Binding Contacts}" SelectedItem="{Binding SelectedContact}" DisplayMemberPath="Name" />
        <TextBlock Grid.Row="1" Grid.Column="0" Text="Billing Address" />
        <ComboBox Grid.Row="1" Grid.Column="1" ext:Selector.Context="{Binding SelectedContext}" />
    </Grid>
</Window>
If you run the demo you'll see there are no `null` addresses popping up when switching contexts, simply because we implement `SelectedItem` on the context itself (i.e. the abstraction between the viewmodel and the view). Any *billing address changed* logic could easily be injected into or implemented in the context.
The other post I referenced puts the emphasis on storing state until the context becomes active again, e.g. `SelectedItem`. In this post we create `ItemsContext`s on the fly, as there could be many contacts. You can, of course, tweak this however you like.
