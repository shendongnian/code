    [ComVisibleAttribute(true)]
    [GuidAttribute("496B0ABF-CDEE-11d3-88E8-00902754C43A")]
    public interface IEnumerator
    {
        Object Current {get;}
        bool MoveNext();
        void Reset();
    }
