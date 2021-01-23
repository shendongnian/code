        ''' <summary>
        ''' Asks the kernel to inject this instance.
        ''' </summary>
        Protected Overridable Sub RequestActivation()
            ServiceLocator.Kernel.Inject(Me)
        End Sub
