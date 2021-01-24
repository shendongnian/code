        private TRet ConvertIt<TRet, TOrig>(TOrig values) where TOrig : struct, IConvertible where TRet : struct, IConvertible
        {
            if (!typeof(TOrig).IsEnum || 
                !typeof(TRet).IsEnum ||
                !typeof(int).IsAssignableFrom(typeof(TOrig)) || 
                !typeof(int).IsAssignableFrom(typeof(TRet)))
            {
                throw new ArgumentException("TOrig and TRet must be an enumerated type extending integer");
            }
            bool retEnumHasZero = false;
            foreach (var flag in Enum.GetValues(typeof(TRet)))
            {
                if ((int)flag == 0)
                {
                    retEnumHasZero = true;
                    break;
                }
            }
            if (!retEnumHasZero)
            {
                throw new ArgumentException("TRet enum must have the 0 flag");
            }
            Dictionary<int, Enum> valsOrig = new Dictionary<int, Enum>();
            foreach (var flag in Enum.GetValues(typeof(TOrig)))
            {
                valsOrig.Add((int)flag, (Enum)flag);
            }
            
            object valuesAsObject = values;
            var valuesAsEnum = (Enum)valuesAsObject;
            int returnedValue = 0;
            foreach (var flag in Enum.GetValues(typeof(TRet)))
            {
                int flagAsInt = (int)flag;
                
                if (valsOrig.ContainsKey(flagAsInt) && valuesAsEnum.HasFlag(valsOrig[flagAsInt]))
                {
                    returnedValue |= flagAsInt;
                }
            }
            return (TRet)Enum.ToObject(typeof(TRet), returnedValue);
        }
Using the function :
A valAsA = A.One | A.Two | A.Three | A.Four;
C valAsCNewV = ConvertIt<C, A>(valAsA);
