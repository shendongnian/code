             public object FindObject(object OBJ, string PropName)
         {
             PropertyInfo[] pi = OBJ.GetType().GetProperties();
             for (int i = 0; i < pi.Length; i++)
             {
                 if (pi[i].PropertyType.Name.Contains(PropName))
                 {
                     if (pi[i].CanRead)                     //Check that you can read it first
                        return pi[i].GetValue(OBJ, null);   //Get the value of the property
                 }
             }
             return new object();
         }
