c#
namespace WpfApp.Models
{
    public interface IEntity
    {
        string Name { get; }
    }
    
    public class Dog : IEntity
    {
        public Dog(string breed, string name)
        {
            Breed = breed;
            Name = name;
        }
        public string Breed { get; }
        public string Name { get; }
    }
    public class Author : IEntity
    {
        public Author(string genre, string name)
        {
            Genre = genre;
            Name = name;
        }
        public string Genre { get; }
        public string Name { get; }
    }
}
Next, the ViewModels, starting with our context.
c#
namespace WpfApp.ViewModels
{
    public class ItemsContext : ViewModelBase
    {
        public ItemsContext(IEnumerable<IEntity> items)
        {
            if (items == null || !items.Any()) throw new ArgumentException(nameof(Items));
            Items = new ObservableCollection<IEntity>(items);
            SelectedItem = Items.First();
        }
        public ObservableCollection<IEntity> Items { get; }
        private IEntity selectedItem;
        public IEntity SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        public string DisplayMemberPath { get; set; }
    }
}
As said, the relevant properties, with notifications for `SelectedItem`, nothing special. We immediately see the effect on our `MainViewModel`.
C#
namespace WpfApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ItemsContext _dogContext;
        private readonly ItemsContext _authorContext;
        public MainViewModel()
        {
            _dogContext = new ItemsContext(FetchDogs()) { DisplayMemberPath = nameof(Dog.Breed) };
            _authorContext = new ItemsContext(FetchAuthors()) { DisplayMemberPath = nameof(Author.Genre) };
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
        private bool dogChecked;
        public bool DogChecked
        {
            get { return dogChecked; }
            set
            {
                dogChecked = value;
                if(dogChecked) SelectedContext = _dogContext;
            }
        }
        private bool authorChecked;
        public bool AuthorChecked
        {
            get { return authorChecked; }
            set
            {
                authorChecked = value;
                if(authorChecked) SelectedContext = _authorContext;
            }
        }
        private static IEnumerable<IEntity> FetchDogs() =>
            new List<IEntity>
            {
                new Dog("Terrier", "Ralph"),
                new Dog("Beagle", "Eddy"),
                new Dog("Poodle", "Fifi")
            };
        private static IEnumerable<IEntity> FetchAuthors() =>
            new List<IEntity>
            {
                new Author("SciFi", "Bradbury"),
                new Author("RomCom", "James")
            };
    }
}
Two cleanly separated flows, each managing its own context. It's clear you could easily extend this to any number of contexts, without them getting in each others way. Now, to apply the context to our `ItemsControl` we have two options. We could subclass our `Control` or use an Attached Property. Favoring composition over inheritance, here's the class with the AP.
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
That covers both steps 2 and 3. You can tweak this however you like. For example, we've made `ItemsContext.DisplayMemberPath` a non notifying prop, so you could just set the value directly instead of through binding.
Finally, the view, where it all comes together.
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
        <vm:MainViewModel/>
    </Window.DataContext>
    <Window.Resources>
        <Style x:Key="SelectorStyle" TargetType="{x:Type Selector}">
            <Setter Property="Width" Value="150"/>
            <Setter Property="HorizontalAlignment" Value="Left"/>
            <Setter Property="Margin" Value="0,20"/>
        </Style>
    </Window.Resources>
    <StackPanel Margin="20">
        <RadioButton GroupName="Entities" Content="Dogs" IsChecked="{Binding DogChecked}" />
        <RadioButton GroupName="Entities" Content="Authors" IsChecked="{Binding AuthorChecked}" />
        <ComboBox ext:Selector.Context="{Binding SelectedContext}" Style="{StaticResource SelectorStyle}" />
        <ListBox  ext:Selector.Context="{Binding SelectedContext}" Style="{StaticResource SelectorStyle}" />
        <DataGrid ext:Selector.Context="{Binding SelectedContext}" Style="{StaticResource SelectorStyle}" />
    </StackPanel>
</Window>
The cool thing about the Attached Property is that we're coding against the abstract `Selector` control, which is a direct descendant of `ItemsControl`. So without changing our lower layers we can share our context with `ListBox` and `DataGrid` as well.
