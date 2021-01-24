    private void ChangeSkin(Skin skin)
    {
        ResourceDictionary theme = null;
        switch (skin)
        {
            case Skin.Light:
                theme = new ResourceDictionary { Source = new Uri("pack://application:,,,/Foo.Core.WPF;component/Resources/Dictionary_LightTheme.xaml") };
                break;
            case Skin.Dark:
                theme = new ResourceDictionary { Source = new Uri("pack://application:,,,/Foo.Core.WPF;component/Resources/Dictionary_DarkTheme.xaml") };
                break;
        }
        if (theme != null)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(theme);
        }
    }
