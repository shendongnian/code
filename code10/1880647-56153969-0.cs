StringBuilder convertedId = new StringBuilder();
            var idToByte = Encoding.ASCII.GetBytes(id);
            using (SHA1 sha1 = SHA1.Create())
            {
                var bytes = sha1.ComputeHash(idToByte);
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (i == 0 && bytes[i] < 16)
                        convertedId.Append(bytes[i].ToString("x1"));
                    else
                        convertedId.Append(bytes[i].ToString("x2"));
                }
            }
            return convertedId.ToString();
