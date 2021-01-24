using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
csharp
var password = "pass";
var salt = "saltsaltsaltsalt";
string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Convert.FromBase64String(salt),
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 64));
Console.WriteLine(hashed);
I can currently not verify that this gives you the same hash as your NodeJS code.
