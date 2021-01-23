        public string GetIPv4Mask(string nicName)
        {
            const string cmd = "ifconfig";
            var args = nicName;
        
            var output = RunProcessCapturingOutput(cmd, args);
        
            var pos = output.IndexOf("Mask:");
            if (pos > -1)
            {
                var posEnd = output.IndexOf(Environment.NewLine, pos);
        
                return posEnd > -1 ? output.Substring(pos + 5, posEnd - pos - 5) : output.Substring(pos + 5);
            }
        
            return "";
        }
