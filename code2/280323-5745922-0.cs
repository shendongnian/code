    // define a defaultModel
    var defaultModel = new { HomeAddress = new { PostCode = new { Town = "Default Town" } } };
    // null coalesce through the chain setting defaults along the way.
    var town = (((Staff ?? defaultModel)
                    .HomeAddress  ?? defaultModel.HomeAddress)
                        .PostCode ?? defaultModel.HomeAddress.PostCode)
                            .Town ?? defaultModel.HomeAddress.PostCode.Town;
