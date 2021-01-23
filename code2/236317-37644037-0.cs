    <System.Runtime.CompilerServices.Extension()>
    Public Sub BeginLoadData(dataGridView As DataGridView)
        dataGridView.Tag = dataGridView.AutoSizeColumnsMode
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
    End Sub
    <System.Runtime.CompilerServices.Extension()>
    Public Sub EndLoadData(dataGridView As DataGridView)
        dataGridView.AutoSizeColumnsMode = CType(dataGridView.Tag, DataGridViewAutoSizeColumnsMode)
    End Sub
