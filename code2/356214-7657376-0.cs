    public string MeAndMyParentCategory
    {
       get
       {
          //I assuming that your 
          // (Child's relation with the parent category called [Parent])
          if(this.Parent != null)
             return string.Format("{0} > {1}", Parent.Name, this.Name);
          return string.Empty
       }
    }
