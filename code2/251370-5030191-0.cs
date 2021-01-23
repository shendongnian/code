    public class ServiceModule : NinjectModule
    {
        public override void Load() {
            Bind<Common.Billing.AuthorizeNet.IBillingGatewayParametersFactory>().To<AuthorizeNetParameterFactory>();
            Bind<Common.Billing.IBillingGateway>().To<Common.Billing.AuthorizeNet.BillingGateway>();
        }
    }
