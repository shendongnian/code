    private async void Button_Click(object sender, RoutedEventArgs e)
    {
    	await Task.Run(async () =>
    		{
    			try
    			{
    				using (var conn = new SqlConnection("...."))
    				{
    					await conn.OpenAsync();
    				}
    			}
    			catch (System.Exception)
    			{
    				MessageBox.Show("err");
    				return;
    			}
    			MessageBox.Show("ok");
    		}
    	);
    }
