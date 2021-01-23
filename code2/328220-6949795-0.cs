    using System;
    using System.Diagnostics;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Web;
    
    public class MyNamespace
    {
        [ServiceContract]
        public interface IUploader
        {
            [OperationContract]
            [WebInvoke(Method = "POST", UriTemplate = "/UploadFile?fileName={fileName}")]
            void Upload(string fileName, Stream stream);
        }
    
        public class Service : IUploader
        {
            public void Upload(string fileName, Stream stream)
            {
                Debug.WriteLine(fileName);
            }
        }
    
        public class MyFactory : ServiceHostFactory
        {
            protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
            {
                return new MyServiceHost(serviceType, baseAddresses);
            }
    
            class MyRawMapper : WebContentTypeMapper
            {
                public override WebContentFormat GetMessageFormatForContentType(string contentType)
                {
                    return WebContentFormat.Raw;
                }
            }
    
            public class MyServiceHost : ServiceHost
            {
                public MyServiceHost(Type serviceType, Uri[] baseAddresses)
                    : base(serviceType, baseAddresses) { }
    
                protected override void OnOpening()
                {
                    base.OnOpening();
    
                    CustomBinding binding = new CustomBinding(new WebHttpBinding());
                    binding.Elements.Find<WebMessageEncodingBindingElement>().ContentTypeMapper = new MyRawMapper();
                    ServiceEndpoint endpoint = this.AddServiceEndpoint(typeof(IUploader), binding, "");
                    endpoint.Behaviors.Add(new WebHttpBehavior());
                }
            }
        }
    }
