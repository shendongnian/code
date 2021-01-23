    ''' <summary>
    ''' Attempts to resolve a missing assembly by searching the current applications resources. <para/>
    ''' Returns the Resolved Assembly or Nothing
    ''' </summary>
    ''' <returns>[Assembly] or [Nothing]</returns>
    Private Function ResolveAssemblies(sender As Object, args As ResolveEventArgs) As Assembly
        Dim BaseAssembly As Assembly = Assembly.GetEntryAssembly()
        Dim ResourceName As [String] = String.Format("{0}.{1}.dll", BaseAssembly.EntryPoint.DeclaringType.[Namespace], New AssemblyName(args.Name).Name)
        Using Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName)
            If Stream Is Nothing Then Return Nothing
            Dim RawAssembly As [Byte]() = New [Byte](Stream.Length - 1) {}
            Stream.Read(RawAssembly, 0, RawAssembly.Length)
            Return Assembly.Load(RawAssembly)
        End Using
    End Function
