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
