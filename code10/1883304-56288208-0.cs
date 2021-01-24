     public List<Something> Fetch(bool? allocated = null){
         if(allocated != null)
         {
             allocated = allocated.Value;
         }
       return (from x in DbContext.Something 
                where x.Active && (allocated == null || x.Allocated == allocated)
                select x).ToList();
    }
