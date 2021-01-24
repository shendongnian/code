    private void btnWcosIAPClick(object sender, RoutedEventArgs e)
    {
    	Task.Run(async () => 
    	{
    	  await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
    	  {
    	      m_OutputList.Clear();
    	      ResultListSource.Source = m_OutputList;
    	      btnWcosIAP.IsEnabled = lstResult.IsEnabled = false;
    	  });
    	  
    	  int iRes = BurningData_Run();
    	
    	  await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
    	  {
    	      btnWcosIAP.IsEnabled = lstResult.IsEnabled = true;
    	      ResultListSource.Source = null;
    	  });
    	});
    }            
    
    private int BurningData_Run()
    {
     m_DATA.RecvMsgCallback += ShowIAPReceiveMessage;
    ..
     m_DATA.RecvMsgCallback -= ShowIAPReceiveMessage;
    }
