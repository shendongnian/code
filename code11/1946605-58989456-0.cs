public static List<object> GetProps(MyClass item)
        {
            if (item.Children == null) return null;
            var childs = item.Children.Select(c => new
            {
                c.Id,
                Title = c.Text,
                Children = GetProps(c)
            }).ToList();
            return new List<object> { childs };
        }
Then use:
var modifiedResult = mainList.Select(c => new
            {
                c.Id,
                Title = c.Text,
                Children = GetProps(c)
            }).ToList();
