           var hello = "Hello world!";
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(hello));
                
                // String representation
                var stringForBytes  = Convert.ToBase64String(bytes);
                // HEX string representation
                var str = new StringBuilder(bytes.Length * 2);
                foreach (var b in bytes)
                {
                    str.Append(b.ToString("X2"));
                }
                var hexString = str.ToString();
            }
