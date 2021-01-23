    //instantiate Mocks in class scope, as an instance of MockRepository
    
    public ChildClass CreateChildClass(int value)
    {
       var childClass = Mocks.PartialMock<ChildClass>();
       childClass.Expect(x => x.Value).Return(value);
       return childClass;            
    }
