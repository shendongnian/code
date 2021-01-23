    private List<string> my_list;
    public ReadOnlyCollection<string> myList
    {
        get { return my_list.AsReadOnly(); }
        private set { my_list = value; }
    }
