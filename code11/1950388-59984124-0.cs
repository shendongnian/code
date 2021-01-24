    using System;
    using System.IO;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Xml;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace TestClient
    {
     	abstract class OperationResult
    	{
    		public bool Success { get; set; }
    		public string ExceptionMessage { get; set; }
    	}
    	
    	class AsymmetricKeyPairPersistenceResult : OperationResult
    	{
    		public string KeyContainerName { get; set; }
    		public string KeyStorageFileFullPath { get; set; }
    		public string KeyStorageTopFolder { get; set; }
    		public string PublicKeyXml { get; set; }
    		public string PublicPrivateKeyPairXml { get; set; }
    	}
    	
    	class AsymmetricEncryptionService
    	{
    		public AsymmetricKeyPairPersistenceResult PersistNewAsymmetricKeyPair(int keySizeBits)
    		{
    			AsymmetricKeyPairPersistenceResult asymmetricKeyPairPersistenceResult = new AsymmetricKeyPairPersistenceResult();
    			try
    			{			
    				RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(keySizeBits);
    				
    				asymmetricKeyPairPersistenceResult.Success = true;
    				asymmetricKeyPairPersistenceResult.PublicKeyXml = rsaProvider.ToXmlString(false);
    				asymmetricKeyPairPersistenceResult.PublicPrivateKeyPairXml = rsaProvider.ToXmlString(true);
    			}
    			catch (Exception ex)
    			{
    				asymmetricKeyPairPersistenceResult.ExceptionMessage = ex.Message;
    			}
    			
    			return asymmetricKeyPairPersistenceResult;
    		}
    	}
    	
    	class Customer{
    		public Customer(string Name) { this.Name = Name; this.GlobalId = Guid.NewGuid().ToString(); }
    		public string Name { get; set; }	
    		public string GlobalId { get; set; }
    	}
    	
        class Program
        {
    		private static readonly Dictionary<string, string> customerDictionary = new Dictionary<string, string>();
            private static readonly HttpClient client = new HttpClient();
            //static IConfiguration configuration;
    
            public static bool StartProcess()
            {
                /*configuration = new ConfigurationBuilder()
                    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
    			*/
                string customerId = createCustomer("Test User").GlobalId;
    
                Console.WriteLine("Customer ID = " + customerId + "\n");
    
    			XmlDocument publicKeyDoc = new XmlDocument();
    			publicKeyDoc.LoadXml(customerDictionary[customerId]);
    			
    			string content = CreateAndSignXML(customerId, publicKeyDoc);
    			Console.WriteLine("License fetched.");
    			Console.WriteLine("-----------------");
    			Console.WriteLine(content + "\n");
    			
    			return VerifySignature(content, publicKeyDoc);
            }
    		
    		private static bool VerifySignature(string content, XmlDocument publicKeyDoc){
    			RSAParameters parameters = new RSAParameters();
    			parameters.Modulus = Convert.FromBase64String(publicKeyDoc.SelectSingleNode("//RSAKeyValue/Modulus").InnerText);
    			parameters.Exponent = Convert.FromBase64String(publicKeyDoc.SelectSingleNode("//RSAKeyValue/Exponent").InnerText);
    			RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
    			rsaKey.ImportParameters(parameters);
    			
    			XmlDocument xmlDoc = new XmlDocument();
    			xmlDoc.PreserveWhitespace = false;
    			xmlDoc.LoadXml(content);
    			SignedXml signedXml = new SignedXml(xmlDoc);
    			XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Signature");
    			signedXml.LoadXml((XmlElement)nodeList[0]);
    			
    			return signedXml.CheckSignature(rsaKey);
    		}
    		
    		private static string CreateAndSignXML(string customerId, XmlDocument publicKeyDoc){
    			Console.WriteLine("Started creating XML..");
    			
    			RSAParameters parameters = new RSAParameters();
    			// Convert.FromBase64String is used instead of Encoding.UTF8.GetBytes
    			parameters.Modulus = Convert.FromBase64String(publicKeyDoc.SelectSingleNode("//RSAKeyValue/Modulus").InnerText);
    			parameters.Exponent = Convert.FromBase64String(publicKeyDoc.SelectSingleNode("//RSAKeyValue/Exponent").InnerText);
    			parameters.D = Convert.FromBase64String(publicKeyDoc.SelectSingleNode("//RSAKeyValue/D").InnerText);
    			parameters.P = Convert.FromBase64String(publicKeyDoc.SelectSingleNode("//RSAKeyValue/P").InnerText);
    			parameters.Q = Convert.FromBase64String(publicKeyDoc.SelectSingleNode("//RSAKeyValue/Q").InnerText);
    			parameters.InverseQ = Convert.FromBase64String(publicKeyDoc.SelectSingleNode("//RSAKeyValue/InverseQ").InnerText);
    			parameters.DP = Convert.FromBase64String(publicKeyDoc.SelectSingleNode("//RSAKeyValue/DP").InnerText);
    			parameters.DQ = Convert.FromBase64String(publicKeyDoc.SelectSingleNode("//RSAKeyValue/DQ").InnerText);
    			RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
    			rsaKey.ImportParameters(parameters);
    			
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = false;
                xmlDoc.LoadXml("<license><mode>Trial</mode><features><feature>All</feature></features></license>");
    			
    			Console.WriteLine("Started signing XML..");
    
                SignedXml signedXml = new SignedXml(xmlDoc);
                signedXml.SigningKey = rsaKey;
                Reference reference = new Reference();
                reference.Uri = string.Empty;
                XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(env);
                signedXml.AddReference(reference);
                signedXml.ComputeSignature();
                XmlElement xmlDigitalSignature = signedXml.GetXml();
                xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
    			
    			MemoryStream stream = new MemoryStream();
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Async = false,
                    Indent = true
                };
                stream.Position = 0;
                var xWriter = XmlWriter.Create(stream, settings);
                xmlDoc.WriteContentTo(xWriter);
                xWriter.Flush();
                stream.Position = 0;
    			
    			Console.WriteLine("Completed creating and signing XML.." + "\n");
    			
    			// Removing BOM character
    			string finalXmlContent = Encoding.UTF8.GetString(stream.ToArray());
    			string byteOrderMarkUTF8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
    			if (finalXmlContent.StartsWith(byteOrderMarkUTF8))
    			{
        			finalXmlContent = finalXmlContent.Remove(0, byteOrderMarkUTF8.Length);
    			}
    
                return finalXmlContent;	
    		}
    		
    		private static Customer createCustomer(string customerName){
    			Customer customer = new Customer(customerName);
    
                AsymmetricEncryptionService asymmetricEncryptionService = new AsymmetricEncryptionService();
                int keySizeBits = 2048;
    
                AsymmetricKeyPairPersistenceResult asymmetricKeyPairPersistenceResult = asymmetricEncryptionService.PersistNewAsymmetricKeyPair(keySizeBits);
    			
                if (asymmetricKeyPairPersistenceResult.Success)
                {
                    customerDictionary.Add(customer.GlobalId.ToString(), asymmetricKeyPairPersistenceResult.PublicPrivateKeyPairXml);
    				
    				Console.WriteLine("Public/Private Key Pair");
    				Console.WriteLine("------------------------");
    				Console.WriteLine(JsonConvert.SerializeObject(customerDictionary) + "\n");
                }	
    			else{
    				Console.WriteLine(asymmetricKeyPairPersistenceResult.ExceptionMessage);
    			}
    
    			Console.WriteLine("Customer is created successfully");
    			
    			return customer;
    		}
            
            public static void Main(string[] args){
                bool result = StartProcess();
                
    			Console.WriteLine("RESULT");
    			Console.WriteLine("-------");
                if (result)
    			{
    				Console.WriteLine("Doc signature is VALID");
    			}
    			else
    			{
    				Console.WriteLine("Doc signature is INVALID");
    			}
            }
        }
    }
