public class Question
    {
        public int que_id { get; set; }
        public string que_text { get; set; }
        public Boolean IsSelected { get; set; }
       
        private bool isSelectedRadioBtn;
        public bool IsSelectedRadioBtn
        {
            get { return isSelectedRadioBtn; }
            set
            {
                isSelectedRadioBtn = value;
                
            }
        }
    }
My XAML part :
ListView.ItemTemplate>
                <DataTemplate>
                    <DockPanel>
                        <TextBlock DockPanel.Dock="Top" x:Name="quebox" Text="{Binding que_text}"
                 Style="{StaticResource ResourceKey=textblock_style }" />
                        <RadioButton  IsChecked="{Binding IsSelectedRadioBtn}" x:Name="yesradiobtn" DockPanel.Dock="Left">yes</RadioButton>
                        <RadioButton   x:Name="noradiobtn" DockPanel.Dock="Right">no</RadioButton>
                    </DockPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
And I m inserting into database on a button click after selecting all the answers like this-
 private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Question> items = (List<Question>)listviewQue.ItemsSource;
            int count = 0;
            int totalcnt = items.Count;
            foreach (Question item in items)
            {
                if (item.IsSelectedRadioBtn)
                {
                    count++;
                    string ans = "yes";
                    string res = SQLiteDataAccess.AddResponse(surveryId, emp[empIndex].Id, item.que_id, ans);
                    if (!(res == SQLiteDataAccess.SUCCESS))
                    {
                        MessageBox.Show("SQLite Exception for 'yes' radiobutton click " + res);
                    }
                }
                else
                {
                    count++;
                    string ans = "no";
                    string res = SQLiteDataAccess.AddResponse(surveryId, emp[empIndex].Id, item.que_id, ans);
                    if (!(res == SQLiteDataAccess.SUCCESS))
                    {
                        MessageBox.Show("SQLite Exception for 'no' button click " + res);
                    }
                }
            }
            if (count != totalcnt)
            {
                MessageBox.Show("Please enter the response for all the questions");
            }
            else
            {
                MessageBox.Show("Response recorded successfully");
            }
        }
