    var data = new MessageData("a", "b", "c", DateTime.Now, "d", "e", DateTime.Now, DateTime.Now, 1, 2, "f", "g");
    data.Items.Add(new MessageItemData("7", "8", DateTime.Now, DateTime.Now, 11, 12));
    data.Items.Add(new MessageItemData("71", "81", DateTime.Now, DateTime.Now, 111, 112));
    var dataType = data.GetType();
    foreach (var propertyInfo in dataType.GetProperties())
    {
        if (propertyInfo.PropertyType.IsInstanceOfType(data.Items))
        {
            foreach (var item in (List<MessageItemData>)propertyInfo.GetValue(data))
            {
                Console.WriteLine(item);
            }
        }
    }
