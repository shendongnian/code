    template<typename T, typename C>
    class Property{
    public:
	  using SetterType = void (C::*)(T);
      using GetterType = T (C::*)() const;
	  Property(C* theObject, SetterType theSetter, GetterType theGetter)
       :itsObject(theObject),
	    itsSetter(theSetter),
		itsGetter(theGetter)
	    { }
	  operator T() const
	    { return (itsObject->*itsGetter)(); }
 	  C& operator = (T theValue) {
	    (itsObject->*itsSetter)(theValue);
		return *itsObject;
      }
    private:
	  C* const itsObject;
	  SetterType const itsSetter;
	  GetterType const itsGetter;
    };
