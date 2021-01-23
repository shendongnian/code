    // inline, no lambdas
    list.Where(delegate(item, index) { return index < list.Count - 1 && list[index + 1] == item; });
    // if we assign the lambda (delegate) to a local variable:
    var lambdaDelegate = (item, index) => index < list.Count - 1 && list[index + 1] == item;
    list.Where(lambdaDelegate);
    // without using lambdas as a shortcut:
    var anonymousDelegate = delegate(item, index)
        {
            return index < list.Count - 1 && list[index + 1] == item;
        }
    list.Where(anonymousDelegate);
    // and if we don't use anonymous methods (which is what lambdas represent):
    function bool MyDelegate<TSource>(TSource source, int index)
    {
        return index < list.Count - 1 && list[index + 1] == item;
    }
    list.Where(MyDelegate);
