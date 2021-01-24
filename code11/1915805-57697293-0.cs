             public void Check<T> (List<T> myList) where T : class
             {
                 var listType = typeof(T);
                 switch (listType.Name)
                {
                   case "List1":
                     break;
                   case "List2":
                     break;
                }
            }
