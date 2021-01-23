        public static string GenerateNonNumericCode(int length)
        {
            string newcode = GenerateCode(length);
            while (IsNumeric(newcode))
            {
                newcode = GenerateCode(length);
            }
            return newcode;
        }
