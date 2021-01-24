public bool Hard
{
    get { return (bool)GetValue(HardProperty); }
    set
    {
        SetValue(HardProperty, value);
        if (value)
        {
            SetValue(MediumProperty, false);
            SetValue(EasyProperty, false);
        }
        else if(!value && !Medium && !Easy)
        {
            SetValue(HardProperty, true);
        }
    }
}
// Using a DependencyProperty as the backing store for Hard.  This enables animation, styling, binding, etc...
public static readonly DependencyProperty HardProperty =
    DependencyProperty.Register("Hard", typeof(bool), typeof(MainPage), new PropertyMetadata(false));
public bool Medium
{
    get { return (bool)GetValue(MediumProperty); }
    set
    {
        SetValue(MediumProperty, value);
        if (value)
        {
            SetValue(EasyProperty, false);
            SetValue(HardProperty, false);
        }
        else if (!value && !Easy && !Hard)
        {
            SetValue(MediumProperty, true);
        }
    }
}
// Using a DependencyProperty as the backing store for Medium.  This enables animation, styling, binding, etc...
public static readonly DependencyProperty MediumProperty =
    DependencyProperty.Register("Medium", typeof(bool), typeof(MainPage), new PropertyMetadata(false));
public bool Easy
{
    get { return (bool)GetValue(EasyProperty); }
    set
    {
        SetValue(EasyProperty, value);
        if (value)
        {
            SetValue(MediumProperty, false);
            SetValue(HardProperty, false);
        }
        else if (!value && !Medium && !Hard)
        {
            SetValue(EasyProperty, true);
        }
    }
}
// Using a DependencyProperty as the backing store for Easy.  This enables animation, styling, binding, etc...
public static readonly DependencyProperty EasyProperty =
    DependencyProperty.Register("Easy", typeof(bool), typeof(MainPage), new PropertyMetadata(true)); ```
