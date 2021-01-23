    Public Class PriorityHeader
        Inherits SoapHeader
        Public Priority As PriorityLevels
        Public Enum PriorityLevels
            LowPriority
            MediumPriority
            HighPriority
        End Enum
    End Class 
