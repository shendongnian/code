        if (!args.Handled) {
            // Sanity checks
            if (args.ColumnToSort != null && args.SortOrder != SortOrder.None) {
				if (this.ShowGroups && args.ColumnToGroupBy.Groupable)
                    this.BuildGroups(args.ColumnToGroupBy, args.GroupByOrder, args.ColumnToSort, args.SortOrder,
                        args.SecondaryColumnToSort, args.SecondarySortOrder);
                else if (this.CustomSorter != null)
                    this.CustomSorter(args.ColumnToSort, args.SortOrder);
                else
				{
					this.Groups.Clear();
                    this.ListViewItemSorter = new ColumnComparer(args.ColumnToSort, args.SortOrder,
                        args.SecondaryColumnToSort, args.SecondarySortOrder);
				}
            }
        }
