    foreach (var prop in persistentclass.PropertyClosureIterator)
    {
        IValue property = prop.Value;
        if (prop.IsComposite)
        {
            var component = (NHibernate.Mapping.Component)prop.Value;
            foreach (var prop2 in component.PropertyIterator)
            {
                foreach (var column in prop2.ColumnIterator)
                {
                    if (column.Text == "my Column")
                    {
                        // do something with the 'prop2'
                    }
                }
            }
        }
        else
        {
            foreach (var column in prop.ColumnIterator)
            {
                if (column.Text == "my Column")
                {
                    // do something with the 'prop'
                }
            }
        }
    }
