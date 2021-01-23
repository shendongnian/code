    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Umbraco.Framework.Diagnostics;
    
    namespace Umbraco.Framework
    {
        /// <summary>
        /// Objects implementing <see cref="AbstractEquatableObject{T}"/> are provided with common functionality for establishing domain-specific equality
        /// and a robust implementation of GetHashCode
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [Serializable]
        public abstract class AbstractEquatableObject<T> where T : AbstractEquatableObject<T>
        {
            /// <summary>
            /// Returns the real type in case the <see cref="object.GetType" /> method has been proxied.
            /// </summary>
            /// <returns></returns>
            /// <remarks></remarks>
            protected internal virtual Type GetNativeType()
            {
                // Returns the real type in case the GetType method has been proxied
                // See http://groups.google.com/group/sharp-architecture/browse_thread/thread/ddd05f9baede023a for clarification
                return GetType();
            }
    
            /// <summary>Returns a hash code for this instance.</summary>
            /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. </returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    // Based on an algorithm set out at http://sharp-architecture.googlecode.com/svn/trunk/src/SharpArch/SharpArch.Core/DomainModel/BaseObject.cs
    
                    var naturalIdMembers = EnsureEqualityComparisonMembersCached();
    
                    // It's possible for two objects to return the same hash code based on 
                    // identically valued properties, even if they're of two different types, 
                    // so we include the object's type in the hash calculation
                    var hashCode = GetType().GetHashCode();
    
                    if (!naturalIdMembers.Any()) return base.GetHashCode();
    
                    foreach (var value in naturalIdMembers
                        .Select(x => x.GetValue(this, null))
                        .Where(x => !ReferenceEquals(x, null)))
                    {
                        // Check if the property value is null or default (e.g. Guid.Empty)
                        // In which case we just want to use the base GetHashCode because we have no other way
                        // of determining if the instances are different
                        if (value.Equals(value.GetType().GetDefaultValue()))
                            hashCode = (hashCode * 41) ^ base.GetHashCode();
                        else
                            hashCode = (hashCode * 41) ^ value.GetHashCode();
                    }
    
                    return hashCode;
                }
            }
    
            /// <summary>Determines whether the specified object is equal to this instance.</summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(obj, null)) return false;
                var incoming = obj as AbstractEquatableObject<T>;
                if (ReferenceEquals(incoming, null)) return false;
                if (ReferenceEquals(this, incoming)) return true;
    
    
                // (APN Oct 2011) Disabled the additional check for GetNativeType().Equals(incoming.GetNativeType())
                // so that we can compare RelationById with Relation using Equals however this may need reinstating
                // and using IComparable instead
                return CompareCustomEqualityMembers(incoming);
            }
    
            /// <summary>
            /// Implements the operator ==.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The result of the operator.</returns>
            /// <remarks></remarks>
            public static bool operator ==(AbstractEquatableObject<T> left, AbstractEquatableObject<T> right)
            {
                // If both are null, or both are same instance, return true.
                if (ReferenceEquals(left, right)) return true;
    
                // If one is null, but not both, return false.
                if (((object)left == null) || ((object)right == null)) return false;
    
                return left.Equals(right);
            }
    
            /// <summary>
            /// Implements the operator !=.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The result of the operator.</returns>
            /// <remarks></remarks>
            public static bool operator !=(AbstractEquatableObject<T> left, AbstractEquatableObject<T> right)
            {
                return !(left == right);
            }
    
            /// <summary>
            /// A static <see cref="ConcurrentDictionary{Type, IEnumerable{PropertyInfo}}"/> cache of natural ids for types which may implement this abstract class.
            /// </summary>
            protected readonly static ConcurrentDictionary<Type, IEnumerable<PropertyInfo>> EqualityComparisonMemberCache = new ConcurrentDictionary<Type, IEnumerable<PropertyInfo>>();
    
            /// <summary>
            /// Gets the natural id members.
            /// </summary>
            /// <returns></returns>
            /// <remarks></remarks>
            protected abstract IEnumerable<PropertyInfo> GetMembersForEqualityComparison();
    
            /// <summary>
            /// Ensures the natural id members are cached in the static <see cref="EqualityComparisonMemberCache"/>.
            /// </summary>
            /// <returns></returns>
            /// <remarks></remarks>
            protected internal virtual IEnumerable<PropertyInfo> EnsureEqualityComparisonMembersCached()
            {
                return EqualityComparisonMemberCache.GetOrAdd(GetNativeType(), x => GetMembersForEqualityComparison());
            }
    
            /// <summary>
            /// Establishes if the natural id of this instance matches that of <paramref name="compareWith"/>
            /// </summary>
            /// <param name="compareWith">The instance with which to compare.</param>
            /// <returns></returns>
            /// <remarks></remarks>
            protected internal virtual bool CompareCustomEqualityMembers(AbstractEquatableObject<T> compareWith)
            {
                // Standard input checks - if it's the same instance, or incoming is null, etc.
                if (ReferenceEquals(this, compareWith)) return true;
                if (ReferenceEquals(compareWith, null)) return false;
    
                // Get the natural id spec
                var naturalIdMembers = EnsureEqualityComparisonMembersCached();
    
                // If the overriding objct hasn't specified a natural id, just return the base Equals implementation
                if (!naturalIdMembers.Any()) return base.Equals(compareWith);
    
                // We have a natural id specified, so compare the members
                foreach (var naturalIdMember in naturalIdMembers)
                {
                    try
                    {
                        // Get the property values of this instance and the incoming instance
                        var localValue = naturalIdMember.GetValue(this, null);
                        var incomingValue = naturalIdMember.GetValue(compareWith, null);
    
                        // If the property values refere to the same instance, or both refer to null, continue the loop
                        if (ReferenceEquals(localValue, incomingValue) || (ReferenceEquals(localValue, null) && ReferenceEquals(incomingValue, null)))
                            continue;
    
                        // If this property value doesn't equal the incoming value, the comparison fails so we can return straight away
                        if (!localValue.Equals(incomingValue)) return false;
                    }
                    catch (Exception ex)
                    {
                        // If there was an error accessing one of the properties, log it and return false
                        LogHelper.TraceIfEnabled<AbstractEquatableObject<T>>("Error comparing {0} to {1}: {2}",
                                                                             () => GetNativeType().Name,
                                                                             () => compareWith.GetNativeType().Name,
                                                                             () => ex.Message);
                        return false;
                    }
                }
    
                // To get this far means we haven't had any misses, so return true
                return true;
            }
        }
    }
