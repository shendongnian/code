    class Bit
    {
        public virtual BS Bs { get; set; }
        public virtual int WholeS
        {
            get { return Bs.Of.CMS.WholeS; }
            set { Bs.Of.CMS.WholeS = value; }
        }
    }
    class BS
    {
        public virtual Of Of { get; set; }
    }
    class Of
    {
        public virtual CMS CMS { get; set; }
    }
    class CMS
    {
        public virtual int WholeS { get; set; }
    }
    class BitMap : ClassMap<Bit>
    {
        public BitMap()
        {
            References(bit => bit.Bs, "BS_S")
                .Not.LazyLoad();  // should take care, that all is join-loaded
        }
    }
    ...
    Bit bit = session.Get<Bit>(25);
    int wholeS = bit.Bs.Of.CMS.WholeS;
