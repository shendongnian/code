    Public Class ComponentPropertyConvention
        Implements IPropertyConvention, IPropertyConventionAcceptance
        Public Sub Accept(ByVal criteria As IAcceptanceCriteria(Of IPropertyInspector)) Implements IConventionAcceptance(Of IPropertyInspector).Accept
           criteria.Expect(Function(inspector) inspector.EntityType.Namespace.EndsWith("Components"))
        End Sub
        Public Sub Apply(ByVal instance As IPropertyInstance) Implements IConvention(Of IPropertyInspector, IPropertyInstance).Apply
            instance.Column(String.Format("{0}_{1}", New String() {instance.EntityType.Name.ToLower(), instance.Property.Name.Dbize()}))
        End Sub
    End Class
