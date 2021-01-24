    public class TestClass
    {
		[TestMethod]
		public void JsonNetSaveLoadTest()
		{
			Debug.WriteLine("Testing Json.NET");
			
			Func<Ciphertext, SEALContext, Ciphertext> roundtrip = (cipher, context) =>
			{
				var clientArray = new [] { new sampleClass { ciphertext = cipher } };
				var settings = new JsonSerializerSettings
				{
					Converters = { new CiphertextConverter(GlobalContext.Context) },
				};
				
				var requestBody = JsonConvert.SerializeObject(clientArray, settings);
				
				Debug.Write("   ");
				Debug.WriteLine(requestBody);
				Debug.WriteLine("   requestBody.Length={0}", requestBody.Length);
				
				var array = JsonConvert.DeserializeObject<sampleClass []>(requestBody, settings);
				
				Assert.IsTrue(array.Length == clientArray.Length);
				
				var reserializedJson = JsonConvert.SerializeObject(array, settings);
				
				Debug.Write("   ");
				Debug.WriteLine(reserializedJson);
				
				Assert.IsTrue(requestBody == reserializedJson);
				return array[0].ciphertext;
			};
			
			SaveLoadTest(roundtrip);
			
			Console.WriteLine("   passed.");
		}
		
		// Adapted from https://github.com/microsoft/SEAL/blob/master/dotnet/tests/CiphertextTests.cs#L113
		[TestMethod]
		public void DirectSaveLoadTest()
		{
			Debug.WriteLine("Testing direct save and load:");
			
			Func<Ciphertext, SEALContext, Ciphertext> roundtrip = (cipher, context) =>
			{
				Ciphertext loaded = new Ciphertext();
				Assert.AreEqual(0ul, loaded.Size);
				Assert.AreEqual(0ul, loaded.PolyModulusDegree);
				Assert.AreEqual(0ul, loaded.CoeffModCount);
				using (MemoryStream mem = new MemoryStream())
				{
					cipher.Save(mem);
					mem.Seek(offset: 0, loc: SeekOrigin.Begin);
					loaded.Load(context, mem);
				}
				return loaded;
			};
			
			SaveLoadTest(roundtrip);
			
			Debug.WriteLine("   passed.");
		}
		
		// Adapted from https://github.com/microsoft/SEAL/blob/master/dotnet/tests/CiphertextTests.cs#L113
        static void SaveLoadTest(Func<Ciphertext, SEALContext, Ciphertext> roundtrip)
        {
            SEALContext context = GlobalContext.Context;
            KeyGenerator keygen = new KeyGenerator(context);
            Encryptor encryptor = new Encryptor(context, keygen.PublicKey);
            Plaintext plain = new Plaintext("2x^3 + 4x^2 + 5x^1 + 6");
            Ciphertext cipher = new Ciphertext();
            encryptor.Encrypt(plain, cipher);
            Assert.AreEqual(2ul, cipher.Size);
            Assert.AreEqual(8192ul, cipher.PolyModulusDegree);
            Assert.AreEqual(4ul, cipher.CoeffModCount);
			var loaded = roundtrip(cipher, context);
			
            Assert.AreEqual(2ul, loaded.Size);
            Assert.AreEqual(8192ul, loaded.PolyModulusDegree);
            Assert.AreEqual(4ul, loaded.CoeffModCount);
            Assert.IsTrue(ValCheck.IsValidFor(loaded, context));
            ulong ulongCount = cipher.Size * cipher.PolyModulusDegree * cipher.CoeffModCount;
            for (ulong i = 0; i < ulongCount; i++)
            {
                Assert.AreEqual(cipher[i], loaded[i]);
            }
        }
	}
    static class GlobalContext
    {
		// Copied from https://github.com/microsoft/SEAL/blob/master/dotnet/tests/GlobalContext.cs
        static GlobalContext()
        {
            EncryptionParameters encParams = new EncryptionParameters(SchemeType.BFV)
            {
                PolyModulusDegree = 8192,
                CoeffModulus = CoeffModulus.BFVDefault(polyModulusDegree: 8192)
            };
            encParams.SetPlainModulus(65537ul);
            BFVContext = new SEALContext(encParams);
            encParams = new EncryptionParameters(SchemeType.CKKS)
            {
                PolyModulusDegree = 8192,
                CoeffModulus = CoeffModulus.BFVDefault(polyModulusDegree: 8192)
            };
            CKKSContext = new SEALContext(encParams);
        }
        public static SEALContext BFVContext { get; private set; } = null;
        public static SEALContext CKKSContext { get; private set; } = null;
		
		public static SEALContext Context => BFVContext;
    }
