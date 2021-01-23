                string[] parts = str.Split('*');
                foreach (var item in parts)
                {
                    if (item.Contains(parm))
                    {
                        string[] values = item.Split(' ');
                        string value = values[1];
                    }
                }
            }
      }
    
         static void Main(string[] args)
        {
            Class1 c = new Class1();
            c.FindString("EXISTS");
        }
    }
