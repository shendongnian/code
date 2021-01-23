    Public Interface IAppB_Project1_Contract(Of Out TKey)
        ReadOnly Property UniqueReference As TKey 
    End Interface
    Public Interface IAppB_Project2_Contract(Of Out TKey)
        Inherits IAppB_Project1_Contract(Of TKey)
    End Interface
    Public Interface IAppB_Project3_Contract
        Function Create(Of T As {Class, IAppB_Project1_Contract(Of TKey)}, 
                        TKey)(ByVal entity As T) As TKey       
    End Interface
