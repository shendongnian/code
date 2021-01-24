    public int Print<T>(string concepto, List<T> data)
    {
        foreach(var element in data)
        {
            var myMember = element.MyMember; // element is of type T which is MyInterface
        }
    }
