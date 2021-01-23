    namespace MyNamespace
    open System
    open System.Collections.Generic;
    open Mono.Addins
    [<assembly:Addin>]
        do()
    [<assembly:AddinDependency("TextEditor", "1.0")>]
        do()
    [<Extension>]
    type MyClass() =
        interface ISparqlCommand with
             member this.Name
                 with get() = 
                     "Finding the path between two tops in a Graph"
             member this.Run(NamespacesDictionary, repository, argsRest) = 
                 new System.Object()
