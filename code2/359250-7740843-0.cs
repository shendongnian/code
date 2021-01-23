    public virtual IEnumerable<IChild> Children 
        { 
            get 
            { 
              List<IChild> list = new List<IChild>();
              list.AddRange(Boys);
              list.AddRange(Girls);  
              return list; 
            } 
        } 
