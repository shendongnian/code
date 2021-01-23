    namespace Server.Contracts.ServiceContracts
    {
        using System;
        using System.Net.Security;
        using System.ServiceModel;
        using Common.Constants.ServiceModel;
        using Common.LogClient;
    
        /// <summary>
        /// Interface that defines the log service contract.
        /// </summary>
        [ServiceContract(
        Name = ServiceContract.LogServiceName,
        Namespace = ServiceContract.LogServiceNamespace,
        ProtectionLevel = ProtectionLevel.None, 
        SessionMode = SessionMode.NotAllowed)]
        public interface ILogService
        {
            [OperationContract(Name = "Deferred", IsOneWay = true)]
            void Deferred(LogSeverity severity, DateTime eventTimeUtc, string actor,
                          uint? deviceId, string message, string stackTrace);
        }
    }
