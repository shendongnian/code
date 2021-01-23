                if (Grid.DataSource == null)
                    return 0;
                else if (Grid.DataSource.GetType() == typeof(DataTable))
                    return (Grid.DataSource as DataTable).Rows.Count;
                else if (Grid.DataSource.GetType().IsGenericType)
                    return (Grid.DataSource as IList).Count;
