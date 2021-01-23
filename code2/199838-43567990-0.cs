    using Windows.UI.Popups; 
    namespace something.MyViewModels
    {
    	public class TestViewModel 
    	{
    		public void aRandonMethode()
    		{
    			MyMessageBox("aRandomMessage");
    		}
    
            public async void MyMessageBox(string mytext)
            {
                var dialog = new MessageDialog(mytext); await dialog.ShowAsync();
            }
        }
    }
