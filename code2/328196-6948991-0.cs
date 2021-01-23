    public static XElement Save(IEnumerable<BaseClass> list)
    {
        var root = new XElement("root");
        foreach (var item in list)
        {
            item.Save(root);
        }
        return root;
    }
