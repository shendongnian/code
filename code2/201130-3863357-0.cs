            private static byte[] CalculateHashCode(SomeComplexTypeDefinedAsDataContract objectGraph)
        {
            using (RIPEMD160 crypto = new RIPEMD160Managed())
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    DataContractSerializer x = new DataContractSerializer(typeof(SomeComplexTypeDefinedAsDataContract ));
                    x.WriteObject(memStream, objectGraph);
                    memStream.Position = 0;
                    return crypto.ComputeHash(memStream);
                }
            }
        }
