                ctx = new SHA512Managed();
            byte[] digestA = new byte[key.Length + salt.Length];                        //1
            ctx.TransformBlock(key, 0, key.Length, digestA, 0);                         //2 
            ctx.TransformBlock(salt, 0, salt.Length, digestA, key.Length);              //3
            byte[] digestB = new byte[key.Length * 2 + salt.Length];                    //4
            ctx.TransformBlock(key, 0, key.Length, digestB, 0);                         //5
            ctx.TransformBlock(salt, 0, salt.Length, digestB, key.Length);              //6
            ctx.TransformBlock(key, 0, key.Length, digestB, key.Length + salt.Length);  //7
            alt_ctx = new SHA512Managed();
            
            alt_result = alt_ctx.ComputeHash(digestB);  
