    using (var enumerator = orderedTable.DefaultView.GetEnumerator())
    {
        if (enumerator.MoveNext())
        {
            bool isLast;
            do
            {
                var current = enumerator.Current;
                isLast = !enumerator.MoveNext();
                //Do stuff here
            } while (!isLast);
        }
    }
