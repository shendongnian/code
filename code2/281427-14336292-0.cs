        public static bool IsPassworded(string file) {
            var bytes = File.ReadAllBytes(file);
            return IsPassworded(bytes);
            return false;
        }
        public static bool IsPassworded(byte[] bytes) {
            var prefix = Encoding.Default.GetString(bytes.Take(2).ToArray());
            if (prefix == "PK") {
                //ZIP and not password protected
                return false;
            }
            if (prefix == "ÐÏ") {
                //Office format.
                
                //Flagged with password
                if (bytes.Skip(0x20c).Take(1).ToArray()[0] == 0x2f) return true; //XLS 2003
                if (bytes.Skip(0x214).Take(1).ToArray()[0] == 0x2f) return true; //XLS 2005
                if (bytes.Skip(0x20B).Take(1).ToArray()[0] == 0x13) return true; //DOC 2005
                if (bytes.Length < 2000) return false; //Guessing false
                var start = Encoding.Default.GetString(bytes.Take(2000).ToArray()); //DOC/XLS 2007+
                start = start.Replace("\0", " ");
                if (start.Contains("E n c r y p t e d P a c k a g e")) return true;
                return false;
            }
            //Unknown.
            return false;
        }
