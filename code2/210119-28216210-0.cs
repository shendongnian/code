    namespace Microsoft.Practices.Unity
    {
        /// <summary>
        /// A class that holds the collection of information for a constructor, 
        /// so that the container can be configured to call this constructor.
        /// This Class is similar to InjectionConstructor, but you need not provide
        /// all Parameters, just the ones you want to override or which cannot be resolved automatically
        /// The given params are used in given order if type matches
        /// </summary>
        public class InjectionConstructorRelaxed : InjectionMember
        {
            private List<InjectionParameterValue> _parameterValues;
            /// <summary>
            /// Create a new instance of <see cref="InjectionConstructor"/> that looks
            /// for a constructor with the given set of parameters.
            /// </summary>
            /// <param name="parameterValues">The values for the parameters, that will
            /// be converted to <see cref="InjectionParameterValue"/> objects.</param>
            public InjectionConstructorRelaxed(params object[] parameterValues)
            {
                _parameterValues = InjectionParameterValue.ToParameters(parameterValues).ToList();
            }
            /// <summary>
            /// Add policies to the <paramref name="policies"/> to configure the
            /// container to call this constructor with the appropriate parameter values.
            /// </summary>
            /// <param name="serviceType">Interface registered, ignored in this implementation.</param>
            /// <param name="implementationType">Type to register.</param>
            /// <param name="name">Name used to resolve the type object.</param>
            /// <param name="policies">Policy list to add policies to.</param>
            public override void AddPolicies(Type serviceType, Type implementationType, string name, IPolicyList policies)
            {
                ConstructorInfo ctor = FindExactMatchingConstructor(implementationType);
                if (ctor == null)
                {
                    //if exact matching ctor not found, use the longest one and try to adjust the parameters.
                    //use given Params if type matches otherwise use the type to advise Unity to resolve later
                    ctor = FindLongestConstructor(implementationType);
                    if (ctor != null)
                    {
                        //adjust parameters
                        var newParams = new List<InjectionParameterValue>();
                        foreach (var parameter in ctor.GetParameters())
                        {
                            var injectionParameterValue =
                                _parameterValues.FirstOrDefault(value => value.MatchesType(parameter.ParameterType));
                            if (injectionParameterValue != null)
                            {
                                newParams.Add(injectionParameterValue);
                                _parameterValues.Remove(injectionParameterValue);
                            }
                            else
                                newParams.Add(InjectionParameterValue.ToParameter(parameter.ParameterType));
                        }
                        _parameterValues = newParams;
                    }
                    else
                    {
                        throw new InvalidOperationException(
                            string.Format(
                                CultureInfo.CurrentCulture,
                                "No constructor found for type {0}.",
                                implementationType.GetTypeInfo().Name));
                    }
                }
                policies.Set<IConstructorSelectorPolicy>(
                    new SpecifiedConstructorSelectorPolicy(ctor, _parameterValues.ToArray()),
                    new NamedTypeBuildKey(implementationType, name));
            }
            private ConstructorInfo FindExactMatchingConstructor(Type typeToCreate)
            {
                var matcher = new ParameterMatcher(_parameterValues);
                var typeToCreateReflector = new ReflectionHelper(typeToCreate);
                foreach (ConstructorInfo ctor in typeToCreateReflector.InstanceConstructors)
                {
                    if (matcher.Matches(ctor.GetParameters()))
                    {
                        return ctor;
                    }
                }
                return null;
            }
        
           private static ConstructorInfo FindLongestConstructor(Type typeToConstruct)
            {
                ReflectionHelper typeToConstructReflector = new ReflectionHelper(typeToConstruct);
                ConstructorInfo[] constructors = typeToConstructReflector.InstanceConstructors.ToArray();
                Array.Sort(constructors, new ConstructorLengthComparer());
                switch (constructors.Length)
                {
                    case 0:
                        return null;
                    case 1:
                        return constructors[0];
                    default:
                        int paramLength = constructors[0].GetParameters().Length;
                        if (constructors[1].GetParameters().Length == paramLength)
                        {
                            throw new InvalidOperationException(
                                string.Format(
                                    CultureInfo.CurrentCulture,
                                    "The type {0} has multiple constructors of length {1}. Unable to disambiguate.",
                                    typeToConstruct.GetTypeInfo().Name,
                                    paramLength));
                        }
                        return constructors[0];
                }
            }
            private class ConstructorLengthComparer : IComparer<ConstructorInfo>
            {
                /// <summary>
                /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
                /// </summary>
                /// <param name="y">The second object to compare.</param>
                /// <param name="x">The first object to compare.</param>
                /// <returns>
                /// Value Condition Less than zero is less than y. Zero equals y. Greater than zero is greater than y.
                /// </returns>
                [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Validation done by Guard class")]
                public int Compare(ConstructorInfo x, ConstructorInfo y)
                {
                    Guard.ArgumentNotNull(x, "x");
                    Guard.ArgumentNotNull(y, "y");
                    return y.GetParameters().Length - x.GetParameters().Length;
                }
            }
        }
    }
