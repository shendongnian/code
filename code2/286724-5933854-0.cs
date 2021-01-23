        public void BindSortedViewToSeries(DataTable unsortedTable, DataView sortedView, NumericTimeSeries series)
        {
            unsortedTable.RowChanged += (sender, args) => MirrorDataView(sortedView, series);
            unsortedTable.TableNewRow += (sender, args) => MirrorDataView(sortedView, series);
            unsortedTable.RowDeleted += (sender, args) => MirrorDataView(sortedView, series);
            MirrorDataView(view, series);
        }
        private static void MirrorDataView(DataView view, NumericTimeSeries series)
        {
            series.Data.DataSource = view.ToTable();
            series.DataBind();
        }
