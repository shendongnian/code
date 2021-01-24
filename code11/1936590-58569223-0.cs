    var root = new List<Root>();
    root.Add(new Root
    {
        Id = 1,
        text = "foo",
        children = new List<Child>()
        {
          
            new Child{
                Id = 1,
                text = "child text",
                children = new List<Child2>(){
                    new Child2{
                        Id = 1,
                        text = "child text",
                        children =  new List<Child3>{
                            new Child3{
                                Id =1,
                                text = "child text"
                            },
                            new Child3{
                                Id =2,
                                text = "child text"
                            }
                        }
                    },
                    new Child2{
                        Id = 2,
                        text = "child text",
                        children =  new List<Child3>{
                            new Child3{
                                Id =3,
                                text = "child text"
                            },
                            new Child3{
                                Id =4,
                                text = "child text"
                            }
                        }
                    }
                }
            },
            //Child 2
           new Child{
                Id = 1,
                text = "child text",
                children = new List<Child2>(){
                    new Child2{
                        Id = 1,
                        text = "child text",
                        children =  new List<Child3>{
                            new Child3{
                                Id =1,
                                text = "child text"
                            },
                            new Child3{
                                Id =2,
                                text = "child text"
                            }
                        }
                    },
                    new Child2{
                        Id = 2,
                        text = "child text",
                        children =  new List<Child3>{
                            new Child3{
                                Id =3,
                                text = "child text"
                            },
                            new Child3{
                                Id =4,
                                text = "child text"
                            }
                        }
                    }
                }
            }
           
        },
    }); 
