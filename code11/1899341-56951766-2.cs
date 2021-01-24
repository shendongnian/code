c#
return GetTermsFromModel(parentType, sortTerms, parentsName, true);
to,
c#
GetTermsFromModel(parentType, sortTerms, parentsName, true);
Then as per @Dialecticus comments removed passing `sortTerms` as input parameter and removed the parameter inside the code and changed `sortTerms.AddRange(...)` to `yield return`.
changed from,
c#
sortTerms.AddRange(parentSortClass.GetTypeInfo()
                       .DeclaredProperties
                       .Where(p => p.GetCustomAttributes<SortableAttribute>().Any())
                       .Select(p => new SortTerm
                       {
                           ParentName = parentSortClass.Name,
                           Name = hasNavigation ? $"{parentsName}.{p.Name}" : p.Name,
                           EntityName = p.GetCustomAttribute<SortableAttribute>().EntityProperty,
                           Default = p.GetCustomAttribute<SortableAttribute>().Default,
                           HasNavigation = hasNavigation
                       }));
to,
c#
foreach (var p in properties)
            {
                yield return new SortTerm
                {
                    ParentName = parentSortClass.Name,
                    Name = hasNavigation ? $"{parentsName}.{p.Name}" : p.Name,
                    EntityName = p.GetCustomAttribute<SortableAttribute>().EntityProperty,
                    Default = p.GetCustomAttribute<SortableAttribute>().Default,
                    HasNavigation = hasNavigation
                };
            }
also for complex properties, changed from,
c#
GetTermsFromModel(parentType, sortTerms, parentsName, true);
to,
c#
var complexProperties = GetTermsFromModel(parentType, parentsName, true);
                    foreach (var complexProperty in complexProperties)
                    {
                        yield return complexProperty;
                    }
And for the final issue I'm facing with the name, adding the below code after the inner `foreach` loop fixed it,
c#
parentsName = parentsName.Replace($".{parentType.Name}", string.Empty);
So here is the complete updated working code:
c#
private static IEnumerable<SortTerm> GetTermsFromModel(
            Type parentSortClass,
            string parentsName = null,
            bool hasNavigation = false)
        {
            var properties = parentSortClass.GetTypeInfo()
                       .DeclaredProperties
                       .Where(p => p.GetCustomAttributes<SortableAttribute>().Any());
            foreach (var p in properties)
            {
                yield return new SortTerm
                {
                    ParentName = parentSortClass.Name,
                    Name = hasNavigation ? $"{parentsName}.{p.Name}" : p.Name,
                    EntityName = p.GetCustomAttribute<SortableAttribute>().EntityProperty,
                    Default = p.GetCustomAttribute<SortableAttribute>().Default,
                    HasNavigation = hasNavigation
                };
            }
            var complexSortProperties = parentSortClass.GetTypeInfo()
                       .DeclaredProperties
                       .Where(p => p.GetCustomAttributes<NestedSortableAttribute>().Any());
            if (complexSortProperties.Any())
            {
                foreach (var parentProperty in complexSortProperties)
                {
                    var parentType = parentProperty.PropertyType;
                    if (string.IsNullOrWhiteSpace(parentsName))
                    {
                        parentsName = parentType.Name;
                    }
                    else
                    {
                        parentsName += $".{parentType.Name}";
                    }
                    var complexProperties = GetTermsFromModel(parentType, parentsName, true);
                    foreach (var complexProperty in complexProperties)
                    {
                        yield return complexProperty;
                    }
                    parentsName = parentsName.Replace($".{parentType.Name}", string.Empty);
                }
            }
        }
