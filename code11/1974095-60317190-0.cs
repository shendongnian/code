    private IServiceProvider MockIServiceProviderForStaticResourceExtension(params KeyValuePair<object, object>[] resources)
    {
        Mock<IServiceProvider> serviceProviderMock = new Mock<IServiceProvider>(MockBehavior.Strict);
        Mock<IXamlSchemaContextProvider> xamlSchemaContextProviderMock = new Mock<IXamlSchemaContextProvider>(MockBehavior.Strict);
        Mock<IAmbientProvider> ambientProviderMock = new Mock<IAmbientProvider>(MockBehavior.Strict);
        Mock<XamlSchemaContext> xamlSchemaContextMock = new Mock<XamlSchemaContext>(MockBehavior.Strict);
        xamlSchemaContextMock.Setup(xsc => xsc.GetXamlType(It.IsAny<Type>())).Returns((Func<Type, XamlType>)(t => GetXamlTypeForType(t, xamlSchemaContextMock.Object)));
        ambientProviderMock.Setup(ap => ap.GetAllAmbientValues(null, false, It.IsAny<IEnumerable<XamlType>>(), It.IsAny<XamlMember[]>())).Returns((Func<IEnumerable<XamlType>, bool, IEnumerable<XamlType>, XamlMember[], IEnumerable<AmbientPropertyValue>>)GetAllAmbientValuesImplementation);
        xamlSchemaContextProviderMock.Setup(xscp => xscp.SchemaContext).Returns(xamlSchemaContextMock.Object);
        serviceProviderMock.Setup(s => s.GetService(typeof(IXamlSchemaContextProvider))).Returns(xamlSchemaContextProviderMock.Object);
        serviceProviderMock.Setup(s => s.GetService(typeof(IAmbientProvider))).Returns(ambientProviderMock.Object);
        serviceProviderMock.Setup(s => s.GetService(It.IsNotIn(typeof(IXamlSchemaContextProvider), typeof(IAmbientProvider)))).Returns(null);
        return serviceProviderMock.Object;
        IEnumerable<AmbientPropertyValue> GetAllAmbientValuesImplementation(IEnumerable<XamlType> ceilingTypes, bool searchLiveStackOnly, IEnumerable<XamlType> types, params XamlMember[] properties)
        {
            Mock<ResourceDictionary> resourceDictionaryMock = new Mock<ResourceDictionary>(MockBehavior.Strict);
            resourceDictionaryMock.Protected().Setup("OnGettingValue", false, ItExpr.Is<object>(o => resources.Any(kvp => kvp.Key.Equals(o))), ItExpr.Ref<object>.IsAny, ItExpr.Ref<bool>.IsAny).CallBase();
            foreach (KeyValuePair<object, object> kvp in resources)
            {
                resourceDictionaryMock.Object.Add(kvp.Key, kvp.Value);
            }
            Mock<AmbientPropertyValue> ambientPropertyValueMock = new Mock<AmbientPropertyValue>(MockBehavior.Strict, null, resourceDictionaryMock.Object);
            return new List<AmbientPropertyValue> { ambientPropertyValueMock.Object };
        }
        XamlType GetXamlTypeForType(Type t, XamlSchemaContext xamlSchemaContext)
        {
            Mock<XamlType> xamlTypeMock = new Mock<XamlType>(MockBehavior.Strict, t, xamlSchemaContext);
            xamlTypeMock.Protected().Setup<XamlMember>("LookupMember", true, "Resources", false).Returns((Func<string, bool, XamlMember>)LookupMemberImplementation);
            xamlTypeMock.Protected().Setup<XamlMember>("LookupMember", true, "BasedOn", false).Returns((Func<string, bool, XamlMember>)LookupMemberImplementation);
            xamlTypeMock.Setup(xt => xt.ToString()).CallBase();
            return xamlTypeMock.Object;
            XamlMember LookupMemberImplementation(string name, bool skipReadOnlyCheck)
            {
                Mock<PropertyInfo> propertyInfoMock = new Mock<PropertyInfo>(MockBehavior.Strict);
                propertyInfoMock.Setup(pi => pi.Name).Returns(name);
                propertyInfoMock.Setup(pi => pi.DeclaringType).Returns(t);
                Mock<XamlMember> xamlMemberMock = new Mock<XamlMember>(MockBehavior.Strict, propertyInfoMock.Object, xamlSchemaContext);
                xamlMemberMock.Setup(xm => xm.ToString()).CallBase();
                return xamlMemberMock.Object;
            }
        }
    }
