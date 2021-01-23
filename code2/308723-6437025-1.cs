    public Parent() : this(5) {  }
    public Parent(int count) : this() {
        this._parentDetails = new List<ParentDetail>();
        for (int i = 0; i < count; i++) {
            ParentDetails.Add(new ParentDetail{ 
                Id = i + 1 
            } );
        }
    }
