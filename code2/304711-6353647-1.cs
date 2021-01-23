    Public Class SomeRolProvider
        Inherits RoleProvider
        Implements IProvider
    
        'this service needs to get initialized
        <Inject()>
        Public Property _memberhip As IMemberschipService
    
        
        Sub New()
            'only this constructor is called
        End Sub
  
    Protected Overrides Function CreateKernel() As Ninject.IKernel
                Dim modules = New NinjectModule() {New Anipmodule()}
        
                Dim kernel = New StandardKernel(modules)
                kernel.Inject(Roles.Provider)
                kernel.Inject(Membership.Provider)
                Return kernel
            End Function
