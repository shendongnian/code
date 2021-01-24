        xaml
        <Window x:Class="SaveNewText.MainWindow"                
           Title="MainWindow" Height="450" Width="800">
            <Grid>
               <TextBox x:Name="DefaultText" Height="250" Width="250" 
               Background="Transparent" 
               Foreground="Black" MouseDown="TextBlock_MouseDown" IsReadOnly="True"/>
               <TextBox x:Name="NewText" Height="250" Width="250" Background="Transparent" 
               Foreground="Black" TextChanged="NewText_TextChanged"/>
            </Grid>
        </Window>
        xaml.cs
        namespace SaveNewText
        {   
          public partial class MainWindow : Window
          {
             public MainWindow()
             {
                InitializeComponent();
                DefaultText.Text = Properties.Settings.Default.TextString;
             }
             private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
             {
               NewText.Focus();
             } 
             private void NewText_TextChanged(object sender, TextChangedEventArgs e)
             {
                 Properties.Settings.Default.TextString = NewText.Text;
                 Properties.Settings.Default.Save();
                 DefaultText.Text = Properties.Settings.Default.TextString;
             }
         }
       }
    
