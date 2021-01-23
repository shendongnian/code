    #region Assembly mscorlib.dll, v4.0.30319
    // C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\mscorlib.dll
    #endregion
    
    using System;
    using System.Collections;
    
    namespace System.Collections.Generic
    {
    	// Summary:
    	//     Supports a simple iteration over a generic collection.
    	//
    	// Type parameters:
    	//   T:
    	//     The type of objects to enumerate.This type parameter is covariant. That is,
    	//     you can use either the type you specified or any type that is more derived.
    	//     For more information about covariance and contravariance, see Covariance
    	//     and Contravariance in Generics.
    	public interface IEnumerator<out T> : IDisposable, IEnumerator
    	{
    		// Summary:
    		//     Gets the element in the collection at the current position of the enumerator.
    		//
    		// Returns:
    		//     The element in the collection at the current position of the enumerator.
    		T Current { get; }
    	}
    }
