    Public MustInherit Class TemplateSelector
        Inherits ContentControl
    
        Public MustOverride Function SelectTemplate(item As Object, container As DependencyObject) As DataTemplate
    
        Protected Overrides Sub OnContentChanged(oldContent As Object, newContent As Object)
            MyBase.OnContentChanged(oldContent, newContent)
    
            ContentTemplate = SelectTemplate(newContent, Me)
        End Sub
    
    End Class
