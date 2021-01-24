    class EnginePart
    {
        byte KeyID { get; set; }
        int Length { get; set; }
        byte[] Value { get; set; }
        public override string ToString()
        {
            return KeyId == "0x40" ? "Oil filter only filters " + value :
                   KeyId == "0x20" ? "Cylinder rotation count is " + value :
                   ...
        }
    }
