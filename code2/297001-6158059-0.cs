        public class ValueForm: Form 
        {      
            public static string GetFromUser(string originalValue) 
            {
              using (ConnectionForm form = new ConnectionForm())
              {
                 form.TheValue = originalValue;
                 var result = form.ShowDialog();
                 if (result == DialogResult.Ok)
                    return form.TheValue;
                 else 
                    return originalValue;
              }
            } 
        
           public string TheValue { 
              get { return textBox1.Text; } 
              set { textBox1.Text = value; }
           }
    
           /* also some code behind your OK & cancel buttons to set 
              DialogResult appropriately, 
              and do any validation that you need to do
           */
    
        }
