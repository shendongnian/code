    public static AsymmetricCipherKeyPair  Generate_EC_P256_Key_Pair(SecureRandom random)
        {
            // Select the curve P-256 //
            string curveName = "P-256";
            X9ECParameters ecP = NistNamedCurves.GetByName(curveName);
            ECDomainParameters dom_parameters = new ECDomainParameters(ecP.Curve, ecP.G, ecP.N);
            // Generate EC Key Pair //
            ECKeyPairGenerator pGen = new ECKeyPairGenerator();
            ECKeyGenerationParameters genParam = new ECKeyGenerationParameters(dom_parameters, random);
            pGen.Init(genParam);
            AsymmetricCipherKeyPair keypair = pGen.GenerateKeyPair();
            
            ECPrivateKeyParameters private_key = (ECPrivateKeyParameters)keypair.Private;
            ECPublicKeyParameters public_key = (ECPublicKeyParameters)keypair.Public;
            BigInteger priv_key_exp = private_key.D;
            BigInteger genx = public_key.Q.XCoord.ToBigInteger();
            BigInteger geny = public_key.Q.YCoord.ToBigInteger();
            BigInteger genx_aff = public_key.Q.AffineXCoord.ToBigInteger();
            BigInteger geny_aff = public_key.Q.AffineYCoord.ToBigInteger();
            ECPoint pub_key_1 = dom_parameters.G.Multiply(priv_key_exp);
            pub_key_1 =pub_key_1.Normalize();
            BigInteger calcx = pub_key_1.XCoord.ToBigInteger();
            BigInteger calcy = pub_key_1.YCoord.ToBigInteger();
            Console.WriteLine("Exponent: " + priv_key_exp.ToString(16));
            Console.WriteLine("Generated X-Coord        : " + genx.ToString(16));
            Console.WriteLine("Generated X-Coord Affine : " + genx_aff.ToString(16));
            Console.WriteLine("Calculated X-Coord Affine: " + calcx.ToString(16));
            Console.WriteLine("\n");
            Console.WriteLine("Generated Y-Coord        : " + geny.ToString(16));
            Console.WriteLine("Generated Y-Coord Affine : " + geny_aff.ToString(16));
            Console.WriteLine("Calculated Y-Coord Affine: " + calcy.ToString(16));
            
            return keypair;
        }
