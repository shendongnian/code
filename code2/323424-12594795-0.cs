	namespace MyApp
	{
	    using System;
	    using System.ComponentModel;
	    /// <summary>
	    /// Replaces a class  of <typeparamref name="T"/> with a class of
	    /// <typeparamref name="TReplace"/> during design.  Useful for
	    /// replacing abstract <see cref="Component"/>s with mock concrete
	    /// subclasses so that designer doesn't complain about trying to instantiate
	    /// abstract classes (designer does this when you try to instantiate
	    /// a class that derives from the abstract <see cref="Component"/>.
	    /// 
	    /// To use, apply a <see cref="TypeDescriptionProviderAttribute"/> to the 
	    /// class <typeparamref name="T"/>, and instantiate the attribute with
	    /// <code>SwitchTypeDescriptionProvider{T, TReplace})</code>.
	    /// 
	    /// E.g.:
	    /// <code>
	    /// [TypeDescriptionProvider(typeof(ReplaceTypeDescriptionProvider{T, TReplace}))]
	    /// public abstract class T
	    /// {
	    ///     // abstract members, etc
	    /// }
	    /// 
	    /// public class TReplace : T
	    /// {
	    ///     // Implement <typeparamref name="T"/>'s abstract members.
	    /// }
	    /// </code>
	    /// 
	    /// </summary>
	    /// <typeparam name="T">
	    /// The type replaced, and the type to which the 
	    /// <see cref="TypeDescriptionProviderAttribute"/> must be
	    /// applied
	    /// </typeparam>
	    /// <typeparam name="TReplace">
	    /// The type that replaces <typeparamref name="T"/>.
	    /// </typeparam>
	    class ReplaceTypeDescriptionProvider<T, TReplace> : TypeDescriptionProvider
	    {
	        public ReplaceTypeDescriptionProvider() :
	            base(TypeDescriptor.GetProvider(typeof(T)))
	        {
	            // Nada
	        }
	        public override Type GetReflectionType(Type objectType, object instance)
	        {
	            if (objectType == typeof(T))
	            {
	                return typeof(TReplace);
	            }
	            return base.GetReflectionType(objectType, instance);
	        }
	        public override object CreateInstance(
	            IServiceProvider provider,
	            Type objectType,
	            Type[] argTypes,
	            object[] args)
	        {
	            if (objectType == typeof(T))
	            {
	                objectType = typeof(TReplace);
	            }
	            return base.CreateInstance(provider, objectType, argTypes, args);
	        }
	    }
	}
