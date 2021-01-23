    Protected Overrides Function CreateKernel() As Ninject.IKernel
            Dim modules = New NinjectModule() {New Anipmodule()}
    
            Dim kernel = New StandardKernel(modules)
            kernel.Inject(Roles.Provider)
            kernel.Inject(Membership.Provider)
            Return kernel
        End Function
