    public static void Main()
            {
                string id = "141241";
                string id1 = "232a23";
                string id2 = "12412a";
    
                validation( id,  id1,  id2);
            }
           
           public static void validation(params object[] list)
            {
                string s = "";
                int result;
                string _Msg = "";
    
                for (int i = 0; i < list.Length; i++)
                {
                    s = (list[i].ToString());
                   
                   if (string.IsNullOrEmpty(s))
                   {
                       _Msg = "Please Enter the value"; 
                   }
    
                   if (int.TryParse(s, out result))
                   {
                       _Msg = "Enter  " + s.ToString() + ", value is Integer";
    
                   }
                   else
                   {
                       _Msg = "This is not Integer value ";
                   }
                }
            }
