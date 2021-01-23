    static void Main()
        {
          // Setup context in a state 
          WorkItemProcessor processor = new WorkItemProcessor(new CancelState());
    
    	  var workItem1 = new WorkItem {  CompletenessConditionHoldsTrue = true };
    	  var workItem2 = new WorkItem {  CancelConditionHoldsTrue = true };
    	  
          // Issue requests, which toggles state 
    	  processor.Process(workItem1);
          processor.Process(workItem2);
                
          Console.Read();
        }
