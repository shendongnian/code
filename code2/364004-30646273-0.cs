    Public Class MainForm
    
      Private WithEvents myObjectContext As ObjectContext
      Private myDbContext As DbContext
    
    ...
    
      Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        myDbContext = New DbContext
        myObjectContext = CType(myDbContext, IObjectContextAdapter).ObjectContext
    
    ...
    
    
      Private Sub ObjectContextSavingChanges(sender As Object, e As EventArgs) Handles myObjectContext.SavingChanges
    
        'Your code hear
      End Sub
