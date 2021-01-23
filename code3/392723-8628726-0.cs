    Func<int,int,int> = (first, second) => {  
                                              var result=2;
                                              int i=2;
                                              while (i < 4000000)
                                              {
                                                  i = first + second;
                                                  if (i % 2 == 0)
                                                  {
                                                      result += i;
                                                  }
                                                  first = second;
                                                  second = i;
                                              }
                                              return result;
                                            };
