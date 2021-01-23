    Private Shared _cnx As String
    Public Shared Property ConexionMySQL() As String
        Get
            Return My.MySettings.Default.conexionbd
        End Get
        Private Set(ByVal value As String)
            _cnx = value
        End Set
    End Property
