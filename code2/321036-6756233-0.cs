    Public Class Main
        Public Sub SortByLoginTime(accounts As IList(Of UserAccount))
            Array.Sort(accounts, New UserAccountLoginTimeComparer)
        End Sub
        Public Sub SortByScore(accounts As IList(Of UserAccount))
            Array.Sort(accounts, New UserAccountScoreComparer)
        End Sub
    End Class
    Public Class UserAccount
        Public Property LoginTime As Date
        Public Property Score As Integer
    End Class
    Public Class UserAccountLoginTimeComparer
        Implements IComparer(Of UserAccount)
        Public Function Compare(x As UserAccount, y As UserAccount) As Integer Implements System.Collections.Generic.IComparer(Of UserAccount).Compare
            Return Date.Compare(x.LoginTime, y.LoginTime)
        End Function
    End Class
    Public Class UserAccountScoreComparer
        Implements IComparer(Of UserAccount)
        Public Function Compare(x As UserAccount, y As UserAccount) As Integer Implements System.Collections.Generic.IComparer(Of UserAccount).Compare
            Return x.Score - y.Score
        End Function
    End Class
