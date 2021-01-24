xaml
<TabbedPage xmlns="http://xamarin.com/schemas/2014/forms" 
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
             x:Class="CustomTabbedPage.MainPage"
             xmlns:android="clr-namespace:Xamarin.Forms.PlatformConfiguration.AndroidSpecific;assembly=Xamarin.Forms.Core"
             android:TabbedPage.ToolbarPlacement="Bottom">
    <TabbedPage.Children>   
        <ContentPage Title="Home" Icon="ic_home.png" BackgroundColor="White"/>
        <ContentPage Title="Favorites" Icon="ic_favorite.png" BackgroundColor="White"/>
        <ContentPage Title="App" Icon="app_logo_unselected.png" x:Name="home" BackgroundColor="White"/>
        <ContentPage Title="Friends" Icon="ic_people.png" BackgroundColor="White"/>
        <ContentPage Title="Settings" Icon="ic_settings.png" BackgroundColor="White"/>
    </TabbedPage.Children>
</TabbedPage>
iOS Custom Renderer:
c#
public class ExtendedTabbedPageRenderer : TabbedRenderer
{
    public override void ViewWillAppear(bool animated)
    {
        if (TabBar?.Items == null)
            return;
        var tabs = Element as TabbedPage;
        if (tabs != null)
        {
            for (int i = 0; i < TabBar.Items.Length; i++)
            {
                UpdateTabBarItem(TabBar.Items[i], tabs.Children[i].Icon);
            }
        }
        base.ViewWillAppear(animated);
    }
    private void UpdateTabBarItem(UITabBarItem item, string icon)
    {
        if (item == null || icon == null)
            return;
        // Set the font for the title.
       item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("GillSans-UltraBold", 12), TextColor = Color.FromHex("#757575").ToUIColor() }, UIControlState.Normal);
       item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("GillSans-UltraBold", 12), TextColor = Color.FromHex("#3C9BDF").ToUIColor() }, UIControlState.Selected);
    }
}
Android Custom Renderer:
c#
public class ExtendedTabbedPageRenderer : TabbedPageRenderer
    {
        Xamarin.Forms.TabbedPage tabbedPage;
        BottomNavigationView bottomNavigationView;
        Android.Views.IMenuItem lastItemSelected;
        int lastItemId=-1;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                tabbedPage = e.NewElement as ExtendedTabbedPage;
                bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
                bottomNavigationView.NavigationItemSelected += BottomNavigationView_NavigationItemSelected;
                //Call to change the font
                ChangeFont();
            }
            if (e.OldElement != null)
            {
                bottomNavigationView.NavigationItemSelected -= BottomNavigationView_NavigationItemSelected;
            }
        }
        //Change Tab font
        void ChangeFont()
        {
            var fontFace = Typeface.CreateFromAsset(Context.Assets, "gilsansultrabold.ttf");
            var bottomNavMenuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;
            for (int i = 0; i < bottomNavMenuView.ChildCount; i++)
            {
                var item = bottomNavMenuView.GetChildAt(i) as BottomNavigationItemView;
                var itemTitle = item.GetChildAt(1);
                var smallTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(0));
                var largeTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(1));
                lastItemId = bottomNavMenuView.SelectedItemId;
             
                smallTextView.SetTypeface(fontFace, TypefaceStyle.Bold);
                largeTextView.SetTypeface(fontFace, TypefaceStyle.Bold);
                //Set text color
                var textColor = (item.Id == bottomNavMenuView.SelectedItemId) ? tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().GetBarSelectedItemColor().ToAndroid() : tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().GetBarItemColor().ToAndroid();
                smallTextView.SetTextColor(textColor);
                largeTextView.SetTextColor(textColor);
            }
        }
        void BottomNavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            var normalColor = tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().GetBarItemColor().ToAndroid();
            var selectedColor = tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().GetBarSelectedItemColor().ToAndroid();
            if(lastItemId!=-1)
            {
                SetTabItemTextColor(bottomNavMenuView.GetChildAt(lastItemId) as BottomNavigationItemView, normalColor);
            }
            SetTabItemTextColor(bottomNavMenuView.GetChildAt(e.Item.ItemId) as BottomNavigationItemView, selectedColor);
            
            this.OnNavigationItemSelected(e.Item);
            lastItemId = e.Item.ItemId;
        }
        void SetTabItemTextColor(BottomNavigationItemView bottomNavigationItemView, Android.Graphics.Color textColor)
        {
            var itemTitle = bottomNavigationItemView.GetChildAt(1);
            var smallTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(0));
            var largeTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(1));
            smallTextView.SetTextColor(textColor);
            largeTextView.SetTextColor(textColor);
        }
}
  [1]: https://xamgirl.com/extending-tabbedpage-in-xamarin-forms/
