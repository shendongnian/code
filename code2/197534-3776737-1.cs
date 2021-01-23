    public IEnumerable<T> ElementsAt(this IEnumerable<T> list, IEnumerable<int> indexes)
    {
         foreach(var index in indexes)
         {
               yield return list.ElementAt(index);
         }
       
    }
