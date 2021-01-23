     public void UpdateOutput(string text)
         {
             this.Invoke((MethodInvoker) delegate {
               lstOutput.Items.Add(text);
             });
         }
