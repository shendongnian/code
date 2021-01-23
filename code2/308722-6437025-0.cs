    public Parent(int count) : this() {
        for (int i = 0; i < count; i++) {
            ParentDetails.Add(new ParentDetail{ 
                Id = i + 1 
            } );
        }
    }
