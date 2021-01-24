     public void Function()
      {
         List<int> Collection = new List<int>();
         Collection.Add(1);
         Collection.Add(2);
         Collection.Add(3);
         Collection.Add(7);
         Collection.Add(9);
         Collection.Add(5);
         Collection.Add(25);
         foreach (int Elem in Collection)
         {
            int Result = 0;
            Result = Result + Elem;
         }
      }
