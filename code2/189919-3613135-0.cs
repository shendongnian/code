    #if NUNIT  
    using MyAttrib = System.Diagnostics.ConditionalAttribute;  
    #else  
    using MyAttrib = System.ObsoleteAttribute;  
    #endif  
