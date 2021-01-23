       class MyDialogWindow
       {
           public string UserEnteredData { get; set; }
       }
        
        
       if (form.ShowDialog().Value) 
       {    
          string res = dialog.UserEnteredData; 
       }
