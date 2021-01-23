                int n = 15; 
               string r = string.Empty;
                int s=0, t=1,u;
                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {                  
                        r += Convert.ToString(s)+Convert.ToString(t);  
                    }
                    else
                    {
                        u = s + t;
                        s = t;
                        t = u;
                        r += Convert.ToString(u);                                         
                    }
                }
                MessageBox.Show(r);
