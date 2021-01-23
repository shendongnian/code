            private string spinString(string s)
            {
                string  ret,
                        temp;
    
                string[] spinables;
    
                int index,
                    i;
    
                Random a;
                
                
                a = new Random();
                ret = null;
                i = 0;
    
                while (true)
                {
                    if (i == s.Length)
                        break;
    
                    if (s[i] == '{')
                    {
                        temp = s.Remove(0, i + 1);
    
                        index = temp.IndexOf('}');
    
                        if (index != -1)
                        {
                            temp = temp.Remove(index, temp.Length - index);
    
                            spinables = temp.Split('|');
    
                            temp = spinables[a.Next(spinables.Count())];
    
                            index = s.IndexOf('}', i);
    
                            if (index != -1)
                            {
                                s = s.Remove(i, index - i + 1);
    
                                s = s.Insert(i, temp);
                            }
    
                            
                        }
    
                    }
    
                    try
                    {
                        ret += s[i];
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                        break;
                    }
    
                    i++;
                    Thread.Sleep(10);
                }
    
    
                return ret;
            }
