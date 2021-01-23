    Public Shared Function GetRestrictionOnIds(ids As List(Of Integer), propertyName As String) As ICriterion
            Dim allParts As IEnumerable(Of List(Of Integer)) = Partition(ids, SplitSize)
            Dim restriction As Disjunction = Restrictions.Disjunction()
            For Each part As List(Of Integer) In allParts
                restriction.Add(Restrictions.In(propertyName, part))
            Next
            Return Restrictions.Conjunction().Add(restriction)
        End Function
