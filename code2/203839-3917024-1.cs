    class my_visitor : public boost::static_visitor<void>
    {
    public:
        // define the operation on KWTokens
        void operator()(KWToken& tok)  const
        {
          //...
          // since tok is well typed, we can access its Synonyms member without any problems.
          DoStuff(tok.Synonyms)
        }
        // and the operation on GOTokens
        void operator()(GOToken& tok) const
        {
          //...
        }
    };
