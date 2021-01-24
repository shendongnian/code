    private void Button_Theme__Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        string[] Color = string.Split(button.Name, "_");
        MethodInfo ColorMethod = typeof(ColorTheme).GetMethod("Theme_" + Color[2]);
        ColorTheme theme = new ColorTheme();
        Color[] ThemeColors = (Color[])ColorMethod.Invoke(theme, null);
        ColorThemeLight = ThemeColors [0];
        ColorThemeMedium = ThemeColors [1];
        ColorThemeDark = ThemeColors [2];     
    }
