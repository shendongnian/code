    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Net.Security;
    using System.Net.Sockets;
    using System.Security.Authentication;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    namespace SslClient {
    class App {
        private static readonly string ServerIpAddress = "127.0.0.1";
        private static readonly int ServerPort = 3000;
        static void Main(string[] args) {
            try {
                using (var client = new TcpClient(ServerIpAddress, ServerPort))
                using (var sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(App_CertificateValidation)) {
                sslStream.AuthenticateAsClient(ServerIpAddress);
                    Console.WriteLine("Device connected.");
     
                    var outputMessage = "Hello";
                    var outputBuffer = Encoding.UTF8.GetBytes(outputMessage);
                    try {
                        sslStream.Write(outputBuffer);
                    } catch (Exception x) {
                        var baseException = x.GetBaseException();
                        Console.WriteLine(baseException);
                    }
                    var inputBuffer = new byte[4096];
                    var inputBytes = 0;
                    while (inputBytes == 0) {
                        inputBytes = sslStream.Read(inputBuffer, 0, inputBuffer.Length);
                    }
                    var inputMessage = Encoding.UTF8.GetString(inputBuffer, 0, inputBytes);
                    Console.WriteLine(inputMessage);
                }
            } catch (Exception ex) {
                Console.WriteLine("***** {0}\n***** {1}!", ex.GetType().Name, ex.Message);
            }
        }
     private static bool App_CertificateValidation(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
            if (sslPolicyErrors == SslPolicyErrors.None) { return true; }
            if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors) { return true; } //we don't have a proper certificate tree
            Console.WriteLine("*** SSL Error: " + sslPolicyErrors.ToString());
            return false;
        }
    }
    }
    
