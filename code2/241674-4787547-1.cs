        public class myModel
    	{
    		public myModel()
    		{
    			Messenger.Default.Register<string>(this, DoSomething);
    		}
    
    		public void DoSomething(string item)
    		{
    			System.Windows.MessageBox.Show(item);
    		}
    	}
