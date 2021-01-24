        private bool CheckValues(/*params here*/)
        {
            var RMMAVals = RMMA(MultiMA1types.VWMA, 2, 160, 10, 2, 128, 0.75, 0.5);
            for (int k = 0;  k<RMMAVals.Length; k++)
            {
                if (RMMAVals[k][0] >= highPrice || RMMAVals[k][0] <= lowPrice)
                    return false;
            }
            return true;
        }
