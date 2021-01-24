xaml
<Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Styles.xaml"></ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
            <local:BindingProxy x:Key="proxy" Data="{Binding}" />
        </ResourceDictionary>        
    </Window.Resources>
...
<local:SomeDataControl LAbel="Apple" DValue="{Binding Path=Data.DVal1, Source={StaticResource proxy}}"></local:SomeDataControl>
and the code for the binding proxy is also very good and easy, it worth to re-share it:
c-sharp
    public class BindingProxy : Freezable
    {
        #region Overrides of Freezable
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }
        #endregion
        public object Data
        {
            get { return (object) GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }
A little explanation also comes in the linked blog post
> The solution to our problem is actually quite simple, and takes advantage of the Freezable class. The primary purpose of this class is to define objects that have a modifiable and a read-only state, but the interesting feature in our case is that Freezable objects can inherit the DataContext even when they’re not in the visual or logical tree.
Thank you all for your support.
  [1]: https://thomaslevesque.com/2011/03/21/wpf-how-to-bind-to-data-when-the-datacontext-is-not-inherited/
