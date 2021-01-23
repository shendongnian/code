    public void Example(){
        IList<B> listB = new List<B>();
        IList<A> listA = listB;
        listA.Add(new A()); // Can't insert A into a list of B
    }
