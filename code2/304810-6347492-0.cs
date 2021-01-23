        byte[] buffer;
        private void writeString(int location, string value, int length)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            if (value.Length < length)
            {
                Array.Copy(encoding.GetBytes(value), 0, buffer, location, value.Length);
                Array.Clear(buffer, location, length - value.Length);
            }
            else Array.Copy(encoding.GetBytes(value), 0, buffer, location, length);
        }
