    _Repository.Stub(x => x.GetDataByRange(Arg<int>.Is.Anything, Arg<int>.Is.Anything))
               .WhenCalled(x => {
                                  var mylist = entitiesList?.Skip((int)x.Arguments[1])?
                                                      .Take((int)x.Arguments[0])?.ToList();
                                  x.ReturnValue = mylist;   
                                });
