    public enum itemsEnum {item1, item2, itemX}
    public void funcTest2(Object sender, EventArgs ea){
        Type tp = typeof(itemsEnum);
        String[] arrItemEnum = Enum.GetNames(tp);
        foreach (String item in arrItemEnum){
            ListBox1.Items.Add(item);
        }
    }
