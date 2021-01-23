    #light
    
    module Module1
    
    open System
    open System.Collections.Generic;
    open CSLib
    
    type MyClass() =
        interface ISparqlCommand with
            member this.Name = 
                "Finding the path between two tops in the Graph"
            member this.Run(NamespacesDictionary, repository, argsRest) = 
                new System.Object()
