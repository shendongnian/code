	public static bool IsAssignableFromGeneric(this Type constraint, Type candidate)
	{
		if (constraint == null)
		{
			throw new ArgumentNullException("constraint");
		}
		if (candidate == null)
		{
			throw new ArgumentNullException("candidate");
		}
		if (constraint.IsGenericParameter) // e.g.: T
		{
			// The constraint is a generic parameter. 
			// First, check if all special attribute constraints are respected.
			var constraintAttributes = constraint.GenericParameterAttributes;
			if (constraintAttributes != GenericParameterAttributes.None)
			{
				// e.g.: where T : struct
				if (constraintAttributes.HasFlag(GenericParameterAttributes.NotNullableValueTypeConstraint) &&
					!candidate.IsValueType)
				{
					return false;
				}
				// e.g.: where T : class
				if (constraintAttributes.HasFlag(GenericParameterAttributes.ReferenceTypeConstraint) &&
					candidate.IsValueType)
				{
					return false;
				}
				// e.g.: where T : new()
				if (constraintAttributes.HasFlag(GenericParameterAttributes.DefaultConstructorConstraint) &&
					candidate.GetConstructor(Type.EmptyTypes) == null)
				{
					return false;
				}
				// TODO: Covariance and contravariance?
			}
			// Then, check if all inherited type constraints are respected.
			// e.g.: where T : BaseType, IInterface1, IInterface2
			foreach (var subConstraint in constraint.GetGenericParameterConstraints())
			{
				if (!subConstraint.IsAssignableFrom(candidate))
				{
					return false;
				}
			}
			return true;
		}
		else if (constraint.IsGenericType) // e.g. Generic<T1, int, T2>
		{
			// The constraint is a generic type.
			var constraintGenericDefinition = constraint.GetGenericTypeDefinition(); // e.g.: Generic<,,>
			var constraintGenericArguments = constraint.GetGenericArguments(); // e.g.: { T1, int, T2 }
			// Check a list of possible candidates:
			//	- the candidate itself
			//  - its base type, if any (i.e.: if the candidate is not of type object)
			//  - its implemented interfaces
			var inheritedCandidates = new List<Type>();
			
			inheritedCandidates.Add(candidate);
			
			if (candidate.BaseType != null)
			{
				inheritedCandidates.Add(candidate.BaseType);
			}
			
			inheritedCandidates.AddRange(candidate.GetInterfaces());
			foreach (var inheritedCandidate in inheritedCandidates)
			{
				if (inheritedCandidate.IsGenericType && 
					inheritedCandidate.GetGenericTypeDefinition() == constraintGenericDefinition)
				{
					// The inherited candidate and the constraint share the same generic definition.
					var inheritedCandidateGenericArguments = inheritedCandidate.GetGenericArguments(); // e.g.: { float, int, string }
					// For each inherited candidate generic argument, recursively check if it is assignable
					// to the equivalent constraint generic argument.
					for (int i = 0; i < constraintGenericArguments.Length; i++)
					{
						if (!constraintGenericArguments[i].IsAssignableFromGeneric(inheritedCandidateGenericArguments[i])) // !T1.IsAssignableFromGeneric(float)
						{
							return false;
						}
					}
					// The inherited candidate matches the generic definition of the constraint
					// and each of its type arguments are assignable to each equivalent type
					// argument of the constraint.
					return true;
				}
			}
			// The constraint is a generic type, but no 
			// inherited type has a matching generic definition.
			return false;
		}
		else
		{
			// The constraint is neither a generic parameter nor a generic type,
			// we can proceed to a regular closed-type check.
			return constraint.IsAssignableFrom(candidate);
		}
	}
