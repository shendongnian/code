    public abstract class PaymentGateway : IPaymentGateway 
    {
        public long Identifier {get;}
        ...
    }
    public class PaymentGatewayFoo : PaymentGateway
    {
        public long Identifier => 1;
        ...
    }
    public class PaymentGatewayBoo : PaymentGateway
    {
        public long Identifier => 2;
        ...
    }
    public class PaymentGatewayProvider
    {
        private IPaymentGateway[] gateways;
        public PaymentGatewayProvider(IPaymentGateway[] gateways)
        {
             this.gateways = gateways;
        }
        public IPaymentGateway GetGateForClient(bool f) //This can be anything that you can use to identify which payment gateway you need
        {
             //As an example I would usually pass in a client or something that I can then use to identify which payment provider is mapped to a certain client, this way you can have hundreds of payment providers, but in your case you just had a boolean, so I used that
             if(f)
                  return gateways.First(f=> f.Identifier == 1);
             return gateways.First(f=> f.Identifier != 1);
        }
    }
    public class OrderService
    {
        private readonly PaymentGatewayProvider _provider;
    
        public void DoOrder(bool isFoo)
        {
            var service = _provider.GetGateForClient(isFoo);
            this._service.Pay();
        }
    }
