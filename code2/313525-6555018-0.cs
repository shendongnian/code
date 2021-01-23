                int zero = 0;              
                int one = 1;
                bool flag=false;                
                try              
                {     
                    try
                    {
                        int error = one / zero; 
                    }
                    catch
                    {
                        flag=false;
                    }
                    if(flag==false)               
                       int error = one / zero;              
                }                
                catch              
                {                  
                    MessageBox.Show("I can never make it here ...");        
                } 
