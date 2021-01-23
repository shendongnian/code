    Imports StructureMap.Graph
    Imports StructureMap.Configuration.DSL
    Imports StructureMap
    
    Public Module Module1
    
        Public Interface IDatabase
            Property ConString As String
        End Interface
    
        Public Class MSSQLConnection
            Implements IDatabase
            Public Property ConString() As String Implements IDatabase.ConString
        End Class
    
        Public Class ExampleClass
            Public Sub New(ByVal SameOldDatabase As IDatabase, ByVal NewDatabase As IDatabase)
                Console.WriteLine(SameOldDatabase.ConString)
                Console.WriteLine(NewDatabase.ConString)
            End Sub
        End Class
    
        Public Class SecondDatabaseConstructorIsAnotherOne
            Implements IRegistrationConvention
    
            Public Sub Process(ByVal type As Type, ByVal registry As Registry) Implements IRegistrationConvention.Process
                Dim ctor = type.GetConstructors().FirstOrDefault(Function(c) c.GetParameters().Where(Function(p) p.ParameterType = GetType(IDatabase)).Count = 2)
                If Not ctor Is Nothing Then
    
                    Dim parameter = New List(Of Object)
    
                    Dim second = False
    
                    For Each o In ctor.GetParameters()
                        If o.ParameterType = GetType(IDatabase) AndAlso second Then
                            parameter.Add(ObjectFactory.GetNamedInstance(Of IDatabase)("secondDB"))
                        Else
                            If o.ParameterType = GetType(IDatabase) Then second = True
                            parameter.Add(ObjectFactory.GetInstance(o.ParameterType))
                        End If
                    Next
    
                    registry.For(type).Use(Function(context) Activator.CreateInstance(type, parameter.ToArray()))
    
                End If
            End Sub
    
        End Class
    
        Sub Main()
    
            Dim con1 = New MSSQLConnection() With {.ConString = "ConnectToFirstDatabase"}
            Dim con2 = New MSSQLConnection() With {.ConString = "ConnectToSecondDatabase"}
    
            ObjectFactory.Initialize(Sub(init)
                                         init.For(Of IDatabase).Use(con1)
                                         init.For(Of IDatabase).Add(con2).Named("secondDB")
                                     End Sub)
    
            ObjectFactory.Configure(Sub(config)
                                        config.Scan(Sub(scan)
                                                        scan.TheCallingAssembly()
                                                        scan.Convention(Of SecondDatabaseConstructorIsAnotherOne)()
                                                    End Sub)
                                    End Sub)
    
            ObjectFactory.GetInstance(Of ExampleClass)()
            Console.ReadLine()
        End Sub
    
    End Module
