    private void M_Grid_ColumnHeaderClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
    {
        if (e.Column.DataMember == "Filed1")
        {
            var list = m_Grid.DataSource;
    
            if (e.Column.SortOrder == Janus.Windows.GridEX.SortOrder.Descending)
            {
                list = list.OrderBy(p => p.ParticipationDate).ToList();
                e.Column.SortOrder = Janus.Windows.GridEX.SortIndicator.Ascending;
            }
            else
            {
                list = list.OrderByDescending(p => p.ParticipationDate).ToList();
                e.Column.SortOrder = Janus.Windows.GridEX.SortIndicator.Descending;
            }
            m_Grid.DataSource = list;
            m_Grid.Refetch();
        }
    }
