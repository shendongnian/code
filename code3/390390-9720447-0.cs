    public struct PricePoints
    {
        decimal? w, p;
        public PricePoints SpecialPrice()
        {
            PricePoints res;
            if (w < p)
            {
                res.p = p;
                res.w = null;
            }
            else if (w > p && p > 0)
            {
                res = this;
            }
            else
            {
                res.w = w;
                res.p = null;
            }
            return res;
        }
    }
