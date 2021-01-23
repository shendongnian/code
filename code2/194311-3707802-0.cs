                string strData=default(string);
                 object obj = Clipboard.GetData(DataFormats.Text);
                
                if (obj == null)
                {
                    
                    return;
                }
                else
                     strData = obj.ToString();
               strData = strData.Replace(",",".") 
               Clipboard.SetData("Text", strData);
