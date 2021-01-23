                Mapper.CreateMap<A, A>()
                .ConvertUsing((s) => {
                    var d = new A(); 
                    d.CollectionProp.AddRange(s.CollectionProp); 
                    return d;
                });
