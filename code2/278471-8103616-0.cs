    Public Class MyInitializer(Of T As DbContext)
        Inherits CreateDatabaseIfNotExists(Of T)
        Protected Overrides Sub Seed(context As T)
            context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Category_Title ON Categories (Title)")
        End Sub
    End Class
