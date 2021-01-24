    internal class FactoryRegistrationSource : IRegistrationSource
    {
        private static MethodInfo openProductBuilder = typeof(Factory).GetMethod(nameof(Factory.CreateProduct));
        public Boolean IsAdapterForIndividualComponents => false;
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            IServiceWithType typedService = service as IServiceWithType;
            if (typedService != null && typedService.ServiceType.IsClosedTypeOf(typeof(IProduct<>)))
            {
                IComponentRegistration registration = RegistrationBuilder.ForDelegate(typedService.ServiceType, (c, p) =>
                 {
                     IFactory factory = c.Resolve<IFactory>();
                     Type productModel = typedService.ServiceType.GetGenericArguments().First();
                     String productIdentifier = productModel.GetCustomAttribute<ProductIdentifierAttribute>()?.Identifier;
                     MethodInfo closedProductBuilder = openProductBuilder.MakeGenericMethod(productModel);
                     Object productObject = closedProductBuilder.Invoke(factory, new object[] { productIdentifier });
                     return productObject;
                 }).As(service).CreateRegistration();
                yield return registration;
            }
            yield break;
        }
    }
