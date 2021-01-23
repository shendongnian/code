            var data = "hello, world";
            // Encode the string (I've chosen UTF8 here)
            var inputBuffer = Encoding.UTF8.GetBytes(data);
            
            using (var ms = new MemoryStream())
            {
                ms.Write(inputBuffer, 0, inputBuffer.Length);
                // Now decode it back
                MessageBox.Show(Encoding.UTF8.GetString(ms.ToArray()));
            }
