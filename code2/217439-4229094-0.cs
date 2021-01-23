    using System.Reflection; 
    int a = 10;
                string str = "10";
                Type a_type = a.GetType(), str_type = str.GetType();
                try
                {
                    if (Convert.ChangeType((object)a, str_type).Equals(str))
                    {
     
                    }
                }
                catch (Exception ex)
                {
                    //Can't to cast one type to other
                }
