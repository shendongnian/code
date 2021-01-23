    public MyRouteList<T> : List<T>
    {
         public override string ToString()
         {
              return string.Join("&", this.Select(x => "list=" + x.ToString()));
         }
    }
