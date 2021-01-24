    var dispatcherObj = Dispatcher.CurrentDispatcher;
    
    string str1 = "NUMBER OF PASSED:" + "\t\t" + passed1.ToString() + Environment.NewLine + "NUMBER OF FAILED:" + "\t" + failed1.ToString();
    
    var tsk1 = Task.Factory.StartNew(()=>
    {
    	foreach (var ch1 in str1)
    	{
    		var char_by_char1 = ch1;
    		dispatcherObj.Invoke(new Action(() =>
    		{                    
    			first_result.Content += char_by_char1.ToString();
    			System.Threading.Thread.Sleep(5);
    		}), DispatcherPriority.Background);
    	}
    });
    
    
    string str2 = "NUMBER OF PASSED:" + "\t\t" + passed2.ToString() + Environment.NewLine + "NUMBER OF FAILED:" + "\t" + failed2.ToString();
    
    var tsk2 = Task.Factory.StartNew(()=>
    {
    	foreach (var ch2 in str2)
    	{
    		var char_by_char2 = ch2;
    		dispatcherObj.Invoke(new Action(() =>
    		{
    			second_result.Content += char_by_char2.ToString();
    			System.Threading.Thread.Sleep(5);
    		}), DispatcherPriority.Background);
    	}
    });
