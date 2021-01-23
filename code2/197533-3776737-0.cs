    public IEnumberable<T> ElementsAt(this IEnumerable<T> list, IEnumberable<int> indexes)
    {
         foreach(var index in indexes)
         {
               yield return list.ElementAt(index);
         }
       
    }
