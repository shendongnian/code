    <UserControl x:Class="MyNamespace.MyPage"  ...>
        <Grid>
            <TextBox x:Name="SomeTextBox" Width="100" />
        </Grid>
    </UserControl>
    
    
    public class MyPage
    {
        public TextBox MyTextBox
        {
            get { return SomeTextBox; }
        }
    }
    
    
    public class SomeOtherClass
    {
        private void SomeFunction()
        {
            var page = new MyPage();
            page.MyTextBox.Text = "some text";
        }
    }
